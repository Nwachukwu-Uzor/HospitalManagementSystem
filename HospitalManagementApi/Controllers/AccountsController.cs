using HospitalManagementApi.Response;
using HospitalManagementServices.Contracts;
using HospitalManagementServices.Dtos.Incoming.Auth;
using HospitalManagementServices.Dtos.Incoming.Doctors;
using HospitalManagementServices.Dtos.Incoming.Patients;
using HospitalManagementServices.Dtos.Incoming.Staff;
using HospitalManagementServices.Dtos.Outgoing.Doctors;
using HospitalManagementServices.Dtos.Outgoing.Patients;
using HospitalManagementServices.Dtos.Outgoing.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IAuthService _authService;

        public AccountsController(IAccountService accountService, IAuthService authService)
        {
            _accountService = accountService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _authService.ValidateUser(loginDTO);

                if (user == null)
                {
                    return Unauthorized(loginDTO);
                }

                return Accepted(new { Token = await _authService.CreateToken(user) });
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, $"Something went wrong in {nameof(Login)}");
                return Problem($"Something went wrong in {nameof(Login)}", statusCode: 500);
            }
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("register/staff")]
        public async Task<IActionResult> RegisterDoctor(StaffCreationDto staff)
        {
            try
            {
                var stf = await _accountService.RegisterNewStaff(staff);

                return Ok(GenerateApiResponse<StaffRequestDto>.GenerateSuccessResponse(stf));
            }
            catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<StaffRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("register/doctor")]
        public async Task<IActionResult> RegisterDoctor(DoctorCreationDto doctor)
        {
            try
            {
                var doc = await _accountService.RegisterNewDoctor(doctor);

                return Ok(GenerateApiResponse<DoctorRequestDto>.GenerateSuccessResponse(doc));
            }
            catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<DoctorRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("register/patient")]
        public async Task<IActionResult> RegisterDoctor(PatientCreationDto patient)
        {
            try
            {
                var pat = await _accountService.RegisterNewPatient(patient);

                return Ok(GenerateApiResponse<PatientRequestDto>.GenerateSuccessResponse(pat));
            }
            catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<PatientRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("admin-modify")]
        public async Task<IActionResult> MakeStaffAdmin(StaffAdminDto staffDto)
        {
            try
            {
                var isChanged = await _accountService.MakeStaffAdmin(staffDto);
                if(!isChanged)
                {
                    return BadRequest(GenerateApiResponse<StaffAdminDto>.GenerateFailureResponse("Unable to create staff"));
                }

                return Ok(GenerateApiResponse<StaffAdminDto>.GenerateEmptySuccessMessage("Successfully made an admin"));
            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<StaffAdminDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpDelete("delete-account")]
        public async Task<IActionResult> DeleteUser()
    }
}
