using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Dtos.Incoming.Departments;
using HospitalManagement.Services.Dtos.Outgoing.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface IDepartmentsService
    {
        Task<DepartmentRequestDto> CreateDepartment(DepartmentCreationDto departmentDto);
        Task<IEnumerable<DepartmentRequestDto>> GetAllDepartments(int page, int size);
        Task<DepartmentRequestDto> GetDepartmentByIdentificationNumber(string identificationNumber);
    }
}
