using HospitalManagement.Api.Response;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Outgoing.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class StaffController : BaseController
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStaff(int page = 1, int size = 25)
        {
            try
            {
                var staff = await _staffService.GetAllStaff(page, size);

                return Ok(GenerateApiResponse<IEnumerable<StaffRequestDto>>.GenerateSuccessResponse(staff));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
