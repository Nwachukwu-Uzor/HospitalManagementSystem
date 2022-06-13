using HospitalManagement.Api.Response;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Departments;
using HospitalManagement.Services.Dtos.Outgoing.Departments;
using HospitalManagement.Services.Dtos.Outgoing.Doctors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
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

        [HttpGet("{departmentNumber}", Name = nameof(GetDeparmentByNumber))]
        public async Task<IActionResult> GetDeparmentByNumber(string departmentNumber)
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
                    nameof(GetDeparmentByNumber),
                    new { departmentNumber = dept.DepartmentNumber },
                    GenerateApiResponse<DepartmentRequestDto>.GenerateSuccessResponse(dept)
                );
            } catch(Exception ex)
            {
                return StatusCode(statusCode: 500, GenerateApiResponse<DepartmentRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }
    }
}
