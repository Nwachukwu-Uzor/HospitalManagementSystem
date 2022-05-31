﻿using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Api.Response;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class DoctorsController : BaseController
    {
        public DoctorsController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService, ISmsService smsService)
        : base(unitOfWork, mapper, accountService, emailService, smsService)
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctorAsync(DoctorRegistrationDto registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            try
            {
                var doctorAccountEntity = _mapper.Map<AppUser>(registrationDto);
                var doctorAccountCreated = await _accountService.CreateUserAccountAsync(doctorAccountEntity, registrationDto.Password);
                var userEntity = _mapper.Map<Doctor>(registrationDto);
                userEntity.UserId = Guid.Parse(doctorAccountCreated.Id);
                userEntity.User = doctorAccountCreated;
                var entityCreated = await _unitOfWork.Doctors.AddAsync(userEntity);
                if (entityCreated == null)
                {
                    return BadRequest("Unable to create doctor account with the data provided");
                }

                var emailToSend = _emailService.CreateAccountRegistrationMail(
                    entityCreated.IdentificationNumber, 
                    entityCreated.User.Email,
                    entityCreated.User.FirstName,
                    entityCreated.User.LastName,
                    "Doctor"
                );

                var isEmailSent = await _emailService.SendMail(emailToSend);

                if (!isEmailSent)
                {
                    return BadRequest("Unable to send email");
                }

                return CreatedAtRoute(
                    nameof(GetDoctorByIdentityNumberAsync),
                    new { doctorIdentityNumber = entityCreated.IdentificationNumber },
                    _mapper.Map<DoctorRequestDto>(entityCreated)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Something wrong {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsAsync(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                var doctors = await _unitOfWork.Doctors.GetAllPaginatedAsync(pageNumber, pageSize);
                return Ok(new ApiResponse<IEnumerable<DoctorRequestDto>>
                {
                    Success = true,
                    Errors = null,
                    Data = _mapper.Map<IEnumerable<DoctorRequestDto>>(doctors)
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get doctors {ex.Message}");
            }
        }

        [HttpGet("{doctorIdentityNumber}", Name = nameof(GetDoctorByIdentityNumberAsync))]
        public async Task<IActionResult> GetDoctorByIdentityNumberAsync(string doctorIdentityNumber)
        {
            try
            {
                var doctor = await _unitOfWork.Doctors.GetDoctorByIdentityNumber(doctorIdentityNumber);

                return Ok(_mapper.Map<DoctorRequestDto>(doctor));
            } catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
