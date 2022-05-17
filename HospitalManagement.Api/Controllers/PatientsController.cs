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
        public PatientsController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService)
        : base(unitOfWork, mapper, accountService, emailService)
        { }

        [HttpPost]
        public async Task<IActionResult> CreatePatientAsync(PatientRegistrationDto patientRegistrationDto)
        {
            try
            {
                var patientIdentityEntity = _mapper.Map<IdentityUser>(patientRegistrationDto);
                var patientAccountCreated = await _accountService.CreateUserAccountAsync(patientIdentityEntity, patientRegistrationDto.Password);
                var patientEntity = _mapper.Map<Patient>(patientRegistrationDto);
                patientEntity.IdentityId = new Guid(patientIdentityEntity.Id);

                var patientCreated = await _unitOfWork.Patients.AddAsync(patientEntity);

                if (patientCreated == null)
                {
                    return BadRequest("Unable to create patient with the data provided");
                }

                var emailToSend = new Email
                {
                    Body = $"<h1>YOU HAVE BEEN SUCCESSFULLY REGISTERED AS A PATIENT</h1>" +
                    $"<p>Your identification number is {patientCreated.IdentificationNumber}</p>",
                    ToEmail = patientRegistrationDto.Email,
                    ToName = $"{patientCreated.FirstName} {patientCreated.LastName}",
                    Subject = "Account Created"
                };

                var isEmailSent = await _emailService.SendMail(emailToSend);

                if (!isEmailSent)
                {
                    return BadRequest("Unable to send email");
                }

                return Ok(_mapper.Map<PatientRequestDto>(patientCreated));

            } catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
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
    }
}
