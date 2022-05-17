using AutoMapper;
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
        public DoctorsController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService)
        : base(unitOfWork, mapper, accountService, emailService)
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
                var doctorAccountEntity = _mapper.Map<IdentityUser>(registrationDto);
                var doctorAccountCreated = await _accountService.CreateUserAccountAsync(doctorAccountEntity, registrationDto.Password);
                var userEntity = _mapper.Map<Doctor>(registrationDto);
                userEntity.IdentityId = Guid.Parse(doctorAccountCreated.Id);
                var entityCreated = await _unitOfWork.Doctors.AddAsync(userEntity);
                if (entityCreated == null)
                {
                    return BadRequest("Invalid entity");
                }

                var emailToSend = new Email
                {
                    Body = $"<h1>YOU HAVE BEEN SUCCESSFULLY REGISTERED AS A DOCTOR</h1>" +
                    $"<p>Your identification number is {userEntity.IdentificationNumber}</p>",
                    ToEmail = userEntity.Email,
                    ToName = $"{userEntity.FirstName} {userEntity.LastName}",
                    Subject = "Account Created"
                };

                var isEmailSent = await _emailService.SendMail(emailToSend);

                if (!isEmailSent)
                {
                    return BadRequest("Unable to send email");
                }

                return CreatedAtAction(
                    nameof(GetDoctorByIdentityNumberAsync), 
                    new { entityCreated.IdentificationNumber }, 
                    new ApiResponse<DoctorRequestDto> { 
                        Success = true,
                        Errors = null,
                        Data = _mapper.Map<DoctorRequestDto>(entityCreated)
                    }
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

        [HttpGet("{doctorIdentityNumber}")]
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
