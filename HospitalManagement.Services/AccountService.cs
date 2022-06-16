using AutoMapper;
using HospitalManagement.BL.Contracts;
using HospitalManagement.BL.Models;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Doctors;
using HospitalManagement.Services.Dtos.Incoming.Patients;
using HospitalManagement.Services.Dtos.Incoming.Staff;
using HospitalManagement.Services.Dtos.Outgoing.Doctors;
using HospitalManagement.Services.Dtos.Outgoing.Patients;
using HospitalManagement.Services.Dtos.Outgoing.Staff;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
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

        public async Task<bool> DeleteAccount(string email)
        {
            var user = _userManager.FindByEmailAsync(email);


            throw new NotImplementedException();
        }

        public Task<bool> LoginAccount(string email, string password)
        {
            throw new NotImplementedException();
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
            _smsService.SendSms(
                new SMS
                {
                    Body = $"Account created successfully {doctorEntity.IdentificationNumber}",
                    To = doctorEntity.PhoneNumber
                }
            );

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
