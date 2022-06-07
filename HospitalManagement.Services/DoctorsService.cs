using AutoMapper;
using HospitalManagement.BL.Contracts;
using HospitalManagement.Data;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Doctors;
using HospitalManagement.Services.Dtos.Outgoing.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IAccountService _accountService;

        public DoctorsService(IMapper mapper, IEmailService emailService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorRequestDto> CreateDoctorAsync(DoctorCreationDto registrationDto)
        {
            try
            {
                var doctorAccountEntity = _mapper.Map<AppUser>(registrationDto);

                var doctorAccountCreated = await _accountService.CreateUserAccountAsync(doctorAccountEntity, registrationDto.Password);
                var userEntity = _mapper.Map<Doctor>(registrationDto);
                var entityCreated = await _unitOfWork.Doctors.AddAsync(userEntity);
                if (entityCreated == null)
                {
                    throw new ArgumentException("Unable to create doctor with the credential provided");
                }

                var emailToSend = _emailService.CreateAccountRegistrationMail(
                    entityCreated.IdentificationNumber,
                    entityCreated.Email,
                    entityCreated.FirstName,
                    entityCreated.LastName,
                    "Doctor"
                );

                var isEmailSent = await _emailService.SendMail(emailToSend);

                return _mapper.Map<DoctorRequestDto>(entityCreated);
            } catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<DoctorRequestDto>> GetAllDoctorsAsync(int pageNumber = 1, int pageSize = 50)
        {
            var doctors = await _unitOfWork.Doctors.GetAllPaginatedAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<DoctorRequestDto>>(doctors);
        }

        public async Task<DoctorRequestDto> GetDoctorByIdentityNumberAsync(string doctorIdentityNumber)
        {
            var doctor = await _unitOfWork.Doctors.GetUserByIdentityNumber(doctorIdentityNumber);

            if (doctor == null)
            {
                throw new ArgumentException("Invalid doctor identification number");
            }

            return _mapper.Map<DoctorRequestDto>(doctor);
        }
    }
}
