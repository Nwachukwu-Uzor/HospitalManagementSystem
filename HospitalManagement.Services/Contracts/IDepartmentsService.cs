using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Dtos.Incoming.Departments;
using HospitalManagement.Services.Dtos.Outgoing.Departments;
using HospitalManagement.Services.Dtos.Outgoing.Staff;
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
        Task<IEnumerable<StaffRequestDto>> GetStaffForDepartment(string departNumber, int page, int size);
    }
}
