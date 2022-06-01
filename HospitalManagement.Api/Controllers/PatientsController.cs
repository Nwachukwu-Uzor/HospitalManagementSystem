using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class PatientsController : BaseController
    {
        public PatientsController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService, ISmsService smsService)
        : base(unitOfWork, mapper, accountService, emailService, smsService)
        { }

        [HttpPost]
        public async Task<IActionResult> CreatePatientAsync(PatientRegistrationDto patientRegistrationDto)
        {
            try
            {
                var patientIdentityEntity = _mapper.Map<AppUser>(patientRegistrationDto);
                var patientAccountCreated = await _accountService.CreateUserAccountAsync(patientIdentityEntity, patientRegistrationDto.Password);
                var patientEntity = _mapper.Map<Patient>(patientRegistrationDto);
                patientEntity.UserId = new Guid(patientIdentityEntity.Id);
                patientEntity.User = patientAccountCreated;

                var patientCreated = await _unitOfWork.Patients.AddAsync(patientEntity);

                if (patientCreated == null)
                {
                    return BadRequest("Unable to create patient with the data provided");
                }

                var emailToSend = _emailService.CreateAccountRegistrationMail(
                   patientCreated.IdentificationNumber,
                   patientCreated.User.Email,
                   patientCreated.User.FirstName,
                   patientCreated.User.LastName,
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
                     _mapper.Map<PatientRequestDto>(patientCreated)
                );

            } catch(Exception ex)
            {
                return BadRequest(new { Message = $"{ex.Message} here" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients(int page = 1, int pageSize = 50)
        {
            try
            {
                var patients = await _unitOfWork.Patients.GetAllPaginatedAsync(page, pageSize);
                
                if (patients == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<PatientRequestDto>>(patients));
            } catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{patientIdentificationNumber}", Name = nameof(GetPatientByIdentityNumberAsync))]
        public async Task<IActionResult> GetPatientByIdentityNumberAsync(string patientIdentificationNumber)
        {
            try
            {
                var patient = await _unitOfWork.Patients.GetPatientByIdentityNumber(patientIdentificationNumber);

                if (patient == null)
                {
                    return NotFound("No patient with the specified identity number, please supply a valid identity number");
                }

                return Ok(_mapper.Map<PatientRequestDto>(patient));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
