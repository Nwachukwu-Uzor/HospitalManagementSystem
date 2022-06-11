using AutoMapper;
using HospitalManagement.BL.Contracts;
using HospitalManagement.Data;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Patients;
using HospitalManagement.Services.Dtos.Outgoing.Patients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class PatientsService : IPatientsService
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;

        public PatientsService(IMapper mapper, IEmailService emailService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }
        public async Task<PatientRequestDto> CreatePatientAsync(PatientCreationDto patientRegistrationDto)
        {
            try
            {
                var patientEntity = _mapper.Map<Patient>(patientRegistrationDto);

                var patientCreated = await _unitOfWork.Patients.CreateAsync(patientEntity, patientRegistrationDto.Password);

                if (patientCreated == null)
                {
                    throw new ArgumentException("Unable to create patient with the data provided");
                }

                var emailToSend = _emailService.CreateAccountRegistrationMail(
                   patientCreated.IdentificationNumber,
                   patientCreated.Email,
                   patientCreated.FirstName,
                   patientCreated.LastName,
                   "Patient"
               );


                await _emailService.SendMail(emailToSend);

                return _mapper.Map<PatientRequestDto>(patientCreated);
            } catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            
        }

        public async Task<IEnumerable<PatientRequestDto>> GetAllPatients(int page = 1, int pageSize = 50)
        {
            var patients = await _unitOfWork.Patients.GetAllPaginatedAsync(page, pageSize);
            return _mapper.Map<IEnumerable<PatientRequestDto>>(patients);
        }

        public async Task<PatientRequestDto> GetPatientByIdentityNumberAsync(string patientIdentificationNumber)
        {
            try
            {
                var patient = await _unitOfWork.Patients.GetUserByIdentityNumber(patientIdentificationNumber);

                if (patient == null)
                {
                    throw new ArgumentException("No patient with the specified identity number, please supply a valid identity number");
                }

                return _mapper.Map<PatientRequestDto>(patient);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
