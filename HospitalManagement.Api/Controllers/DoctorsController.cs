using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Api.Response;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DoctorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsAsync(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                var doctors = await _unitOfWork.Doctors.GetAllPaginatedAsync(pageNumber, pageSize);
                return Ok(new ApiResponse<IEnumerable<DoctorRequestResponse>> { 
                    Success = true,
                    Errors = null,
                    Data = _mapper.Map<IEnumerable<DoctorRequestResponse>>(doctors)
                });
            } catch(Exception ex)
            {
                return BadRequest($"Unable to get doctors {ex.Message}");
            }
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
                var userEntity = _mapper.Map<Doctor>(registrationDto);
                var entityCreated = await _unitOfWork.Doctors.AddAsync(userEntity);
                if (entityCreated == null)
                {
                    return BadRequest("Invalid entity");
                }

                return Ok(new ApiResponse<DoctorRequestResponse> { 
                    Success = true,
                    Errors = null,
                    Data = _mapper.Map<DoctorRequestResponse>(entityCreated)
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Something wrong {ex.Message}");
            }
        }
    }
}
