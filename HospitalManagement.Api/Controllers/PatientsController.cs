using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Api.Response;
using HospitalManagement.Commons.Contracts;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class PatientsController : BaseController
    {
        public PatientsController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService, ISmsService smsService)
        : base(unitOfWork, mapper, accountService, emailService, smsService)
        { }

        [HttpPost]
        public async Task<ActionResult<PatientRequestDto>> CreatePatientAsync(PatientRegistrationDto patientRegistrationDto)
        {
            try
            {
                var patientIdentityEntity = _mapper.Map<AppUser>(patientRegistrationDto);
                var patientAccountCreated = await _accountService.CreateUserAccountAsync(patientIdentityEntity, patientRegistrationDto.Password);
                var patientEntity = _mapper.Map<Patient>(patientRegistrationDto);

                var patientCreated = await _unitOfWork.Patients.AddAsync(patientEntity);

                if (patientCreated == null)
                {
                    return BadRequest(GenerateApiResponse<AppointmentRequestDto>.GenerateFailureResponse("Unable to create patient with the data provided"));
                }

                var emailToSend = _emailService.CreateAccountRegistrationMail(
                   patientCreated.IdentificationNumber,
                   patientCreated.Email,
                   patientCreated.FirstName,
                   patientCreated.LastName,
                   "Patient"
               );


                var isEmailSent = await _emailService.SendMail(emailToSend);
                //var smsToSend = new SMS() { Body = $"Dear {patientRegistrationDto.FirstName}, " +
                    //$"your account has been created with the {patientCreated.IdentificationNumber}", 
                    //To = patientRegistrationDto.PhoneNumber 
                //};
               // var resp = _smsService.SendSms(smsToSend);

               // if (!isEmailSent)
               // {
               //     return BadRequest("Unable to send email");
               // }



                return CreatedAtRoute(
                    nameof(GetPatientByIdentityNumberAsync), 
                    new { patientIdentificationNumber = patientCreated.IdentificationNumber }, 
                     GenerateApiResponse<PatientRequestDto>.GenerateSuccessResponse(_mapper.Map<PatientRequestDto>(patientCreated))
                );

            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<PatientRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRequestDto>>> GetAllPatients(int page = 1, int pageSize = 50)
        {
            try
            {
                var patients = await _unitOfWork.Patients.GetAllPaginatedAsync(page, pageSize);
                

                return Ok(GenerateApiResponse<IEnumerable<PatientRequestDto>>.GenerateSuccessResponse(_mapper.Map<IEnumerable<PatientRequestDto>>(patients)));
            } catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<IEnumerable<PatientRequestDto>>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpGet("{patientIdentificationNumber}", Name = nameof(GetPatientByIdentityNumberAsync))]
        public async Task<ActionResult<PatientRequestDto>> GetPatientByIdentityNumberAsync(string patientIdentificationNumber)
        {
            try
            {
                var patient = await _unitOfWork.Patients.GetUserByIdentityNumber(patientIdentificationNumber);

                if (patient == null)
                {
                    return NotFound(GenerateApiResponse<PatientRequestDto>.GenerateFailureResponse("No patient with the specified identity number, please supply a valid identity number"));
                }

                return Ok(GenerateApiResponse<PatientRequestDto>.GenerateSuccessResponse(_mapper.Map<PatientRequestDto>(patient)));
            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<PatientRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }
    }
}
