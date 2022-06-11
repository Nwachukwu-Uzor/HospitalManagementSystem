using HospitalManagement.Api.Response;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Doctors;
using HospitalManagement.Services.Dtos.Outgoing.Doctors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class DoctorsController : BaseController
    {
        private readonly IDoctorsService _doctorsService;
        public DoctorsController(IDoctorsService doctorsService) : base()
        {
            _doctorsService = doctorsService;
        }

        [HttpPost]
        public async Task<ActionResult<DoctorRequestDto>> CreateDoctorAsync(DoctorCreationDto registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    GenerateApiResponse<DoctorRequestDto>.GenerateFailureResponse("Something went wrong")
                );
            }
            try
            {
                var doctor = await _doctorsService.CreateDoctorAsync(registrationDto);

                return CreatedAtRoute(
                    nameof(GetDoctorByIdentityNumberAsync),
                    new { doctorIdentityNumber = doctor.IdentificationNumber },
                    GenerateApiResponse<DoctorRequestDto>.GenerateSuccessResponse(doctor)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<DoctorRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorRequestDto>>> GetAllDoctorsAsync(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                var doctors = await _doctorsService.GetAllDoctorsAsync(pageNumber, pageSize);
                return Ok(
                    GenerateApiResponse<IEnumerable<DoctorRequestDto>>
                    .GenerateSuccessResponse(doctors)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<DoctorRequestDto>.GenerateFailureResponse($"Unable to get doctors {ex.Message}"));
            }
        }

        [HttpGet("{doctorIdentityNumber}", Name = nameof(GetDoctorByIdentityNumberAsync))]
        public async Task<IActionResult> GetDoctorByIdentityNumberAsync(string doctorIdentityNumber)
        {
            try
            {
                var doctor = await _doctorsService.GetDoctorByIdentityNumberAsync(doctorIdentityNumber);

                return Ok(
                    GenerateApiResponse<DoctorRequestDto>
                        .GenerateSuccessResponse(doctor)
                );
            } catch(Exception ex)
            {
                return BadRequest(
                    GenerateApiResponse<DoctorRequestDto>
                        .GenerateFailureResponse(ex.Message)
                );
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchForDoctor(string name = "", string email = "", int page = 1, int size = 25)
        {
            try
            {
                var doctors = await _doctorsService.SearchForDoctor(name, email, page, size);

                return Ok(
                   GenerateApiResponse<IEnumerable<DoctorRequestDto>>
                       .GenerateSuccessResponse(doctors)
               );
            } catch(Exception ex)
            {
                return BadRequest(
                  GenerateApiResponse<DoctorRequestDto>
                      .GenerateFailureResponse(ex.Message)
              );
            }
        }
    }
}
