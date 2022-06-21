using HospitalManagementApi.Response;
using HospitalManagementServices.Contracts;
using HospitalManagementServices.Dtos.Incoming.Departments;
using HospitalManagementServices.Dtos.Outgoing.Departments;
using HospitalManagementServices.Dtos.Outgoing.Doctors;
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
    [Authorize]
    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentsService _departmentService;
        public DepartmentsController(IDepartmentsService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments(int page=1, int size=25)
        {
            try
            {
                var departments = await _departmentService.GetAllDepartments(page, size);

                return Ok(GenerateApiResponse<IEnumerable<DepartmentRequestDto>>.GenerateSuccessResponse(departments));
            }catch (Exception ex)
            {
                return StatusCode(statusCode: 500, GenerateApiResponse<IEnumerable<DepartmentRequestDto>>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpGet("{departmentNumber}", Name = nameof(GetDepartmentByNumber))]
        public async Task<IActionResult> GetDepartmentByNumber(string departmentNumber)
        {
            try
            {
                var department = await _departmentService.GetDepartmentByIdentificationNumber(departmentNumber);

                return Ok(GenerateApiResponse<DepartmentRequestDto>.GenerateSuccessResponse(department));
            } catch(Exception ex)
            {
                return StatusCode(statusCode: 500, GenerateApiResponse<DepartmentRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentCreationDto department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var dept = await _departmentService.CreateDepartment(department);

                return CreatedAtAction(
                    nameof(GetDepartmentByNumber),
                    new { departmentNumber = dept.DepartmentNumber },
                    GenerateApiResponse<DepartmentRequestDto>.GenerateSuccessResponse(dept)
                );
            } catch(Exception ex)
            {
                return StatusCode(statusCode: 500, GenerateApiResponse<DepartmentRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet("getstaff/{departmentIdentificationNumber}")]
        public async Task<IActionResult> GetStaffForDepartment(string departmentIdentificationNumber, int page=1, int size=25)
        {
            try
            {
                var staff = await _departmentService.GetStaffForDepartment(departmentIdentificationNumber, page, size);

                return Ok(GenerateApiResponse<IEnumerable<StaffRequestDto>>.GenerateSuccessResponse(staff));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
