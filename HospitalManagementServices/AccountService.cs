using AutoMapper;
using HospitalManagementBL.Contracts;
using HospitalManagementBL.Models;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using HospitalManagementServices.Contracts;
using HospitalManagementServices.Dtos.Incoming.Auth;
using HospitalManagementServices.Dtos.Incoming.Doctors;
using HospitalManagementServices.Dtos.Incoming.Patients;
using HospitalManagementServices.Dtos.Incoming.Staff;
using HospitalManagementServices.Dtos.Outgoing.Doctors;
using HospitalManagementServices.Dtos.Outgoing.Patients;
using HospitalManagementServices.Dtos.Outgoing.Staff;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementServices
{
    public class AccountService : IAccountService
    {
        const string PATIENT_INITIALS = "PAT";
        const string STAFF_INITIALS = "STF";
        const string DOCTOR_INITIALS = "DCT";

        const string STAFF_ROLE = "Staff";
        const string ADMIN_ROLE = "Administrator";
        const string PATIENT_ROLE = "Patient";
        
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIdentityNumberGenerator _identityNumberGenerator;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public AccountService(
            UserManager<AppUser> userManager, IUnitOfWork unitOfWork,
            IMapper mapper, IIdentityNumberGenerator identityNumberGenerator,
            IEmailService emailService, ISmsService smsService
        )
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _identityNumberGenerator = identityNumberGenerator;
            _emailService = emailService;
            _smsService = smsService;
        }

        public async Task<bool> DeleteAccount(UserDeleteDto user)
        {
            var _user = await _userManager.FindByEmailAsync(user.Email);

            if (_user == null)
            {
                throw new ArgumentException("No user exists with that email");
            }

            var deleted = await _userManager.DeleteAsync(_user);
            return deleted.Succeeded;
        }

        public async Task<bool> MakeStaffAdmin(StaffAdminDto staffDto)
        {
            var staff = await _unitOfWork.Staff.GetUserByIdentityNumber(staffDto.IdentificationNumber);

            if (staff == null)
            {
                throw new ArgumentException("No staff with the identification number provided");
            }

            var roles = await _userManager.GetRolesAsync(staff);

            var hasRole = roles.Any(r => r == STAFF_ROLE);

            if (!hasRole)
            {
                throw new ArgumentException("The user with the identification number provided is not a staff");
            }

           var added = await _userManager.AddToRoleAsync(staff, ADMIN_ROLE);
            return added.Succeeded;
        }

        public async Task<DoctorRequestDto> RegisterNewDoctor(DoctorCreationDto doctor)
        {
            var doctorEntity = _mapper.Map<Doctor>(doctor);
            var doctorExist = await _unitOfWork.Doctors.GetUserByEmail(doctor.Email);

            if (doctorExist != null)
            {
                throw new ArgumentException($"A doctor already exists with the email provided");
            }

            var department = await _unitOfWork.Departments.GetDepartmentByNumber(doctor.DepartmentNumber);

            if (department == null)
            {
                throw new ArgumentException($"Invalid department Id, please provide a valid department id");
            }

            doctorEntity.Department = department;

            var randomId = _identityNumberGenerator.GenerateIdNumber(DOCTOR_INITIALS);

            while((await _unitOfWork.Doctors.GetUserByIdentityNumber(randomId)) != null)
            {
                randomId = _identityNumberGenerator.GenerateIdNumber(DOCTOR_INITIALS);
            }

            doctorEntity.IdentificationNumber = randomId;

            var isCreated = await _userManager.CreateAsync(doctorEntity, doctor.Password);

            if (!isCreated.Succeeded)
            {
                var errorMessage = new StringBuilder();
                foreach (var error in isCreated.Errors)
                {
                    errorMessage.AppendLine($" {error.Description}");
                }
                throw new ArgumentException($"Unable to create a user with the provided credentials {errorMessage.ToString().Trim()}");
            }

            await _userManager.AddToRoleAsync(doctorEntity, STAFF_ROLE);

            var emailToSend = _emailService.CreateAccountRegistrationMail(
                 doctorEntity.IdentificationNumber,
                 doctorEntity.Email,
                 doctorEntity.FirstName,
                 doctorEntity.LastName,
                 "Doctor"
             );

            var isEmailSent = await _emailService.SendMail(emailToSend);
            //_smsService.SendSms(
            //    new SMS
            //    {
            //        Body = $"Account created successfully {doctorEntity.IdentificationNumber}",
            //        To = doctorEntity.PhoneNumber
            //    }
            //);

            return _mapper.Map<DoctorRequestDto>(doctorEntity);
        }

        public async Task<PatientRequestDto> RegisterNewPatient(PatientCreationDto patient)
        {
            var patientEntity = _mapper.Map<Patient>(patient);
            var patientExist = await _unitOfWork.Patients.GetUserByEmail(patient.Email);

            if (patientExist != null)
            {
                throw new ArgumentException($"A patient already exists with the email provided");
            }

            var randomId = _identityNumberGenerator.GenerateIdNumber(PATIENT_INITIALS);

            while ((await _unitOfWork.Patients.GetUserByIdentityNumber(randomId)) != null)
            {
                randomId = _identityNumberGenerator.GenerateIdNumber(PATIENT_INITIALS);
            }

            patientEntity.IdentificationNumber = randomId;

            var isCreated = await _userManager.CreateAsync(patientEntity, patient.Password);

            if (!isCreated.Succeeded)
            {
                var errorMessage = new StringBuilder();
                foreach (var error in isCreated.Errors)
                {
                    errorMessage.AppendLine($" {error.Description}");
                }
                throw new ArgumentException($"Unable to create a user with the provided credentials {errorMessage.ToString().Trim()}");
            }

            await _userManager.AddToRoleAsync(patientEntity, PATIENT_ROLE);

            var emailToSend = _emailService.CreateAccountRegistrationMail(
                 patientEntity.IdentificationNumber,
                 patientEntity.Email,
                 patientEntity.FirstName,
                 patientEntity.LastName,
                 "Patient"
             );

            var isEmailSent = await _emailService.SendMail(emailToSend);

            return _mapper.Map<PatientRequestDto>(patientEntity);
        }

        public async Task<StaffRequestDto> RegisterNewStaff(StaffCreationDto staff)
        {
            var staffEntity = _mapper.Map<Staff>(staff);
            var staffExist = await _unitOfWork.Staff.GetUserByEmail(staff.Email);

            if (staffExist != null)
            {
                throw new ArgumentException($"A staff already exists with the email provided");
            }

            var department = await _unitOfWork.Departments.GetDepartmentByNumber(staff.DepartmentNumber);

            if (department == null)
            {
                throw new ArgumentException($"Invalid department Id, please provide a valid department id");
            }

            staffEntity.Department = department;

            var randomId = _identityNumberGenerator.GenerateIdNumber(STAFF_INITIALS);

            while ((await _unitOfWork.Staff.GetUserByIdentityNumber(randomId)) != null)
            {
                randomId = _identityNumberGenerator.GenerateIdNumber(STAFF_INITIALS);
            }

            staffEntity.IdentificationNumber = randomId;

            var isCreated = await _userManager.CreateAsync(staffEntity, staff.Password);

            if (!isCreated.Succeeded)
            {
                var errorMessage = new StringBuilder();
                foreach (var error in isCreated.Errors)
                {
                    errorMessage.AppendLine($" {error.Description}");
                }
                throw new ArgumentException($"Unable to create a user with the provided credentials {errorMessage.ToString().Trim()}");
            }

            await _userManager.AddToRoleAsync(staffEntity, STAFF_ROLE);

            var emailToSend = _emailService.CreateAccountRegistrationMail(
                 staffEntity.IdentificationNumber,
                 staffEntity.Email,
                 staffEntity.FirstName,
                 staffEntity.LastName,
                 "Staff"
             );

            var isEmailSent = await _emailService.SendMail(emailToSend);

            return _mapper.Map<StaffRequestDto>(staffEntity);
        }
    }
}
