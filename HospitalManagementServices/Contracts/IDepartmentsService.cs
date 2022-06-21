using HospitalManagementDomain.Models;
using HospitalManagementServices.Dtos.Incoming.Departments;
using HospitalManagementServices.Dtos.Outgoing.Departments;
using HospitalManagementServices.Dtos.Outgoing.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementServices.Contracts
{
    public interface IDepartmentsService
    {
        Task<DepartmentRequestDto> CreateDepartment(DepartmentCreationDto departmentDto);
        Task<IEnumerable<DepartmentRequestDto>> GetAllDepartments(int page, int size);
        Task<DepartmentRequestDto> GetDepartmentByIdentificationNumber(string identificationNumber);
        Task<IEnumerable<StaffRequestDto>> GetStaffForDepartment(string departNumber, int page, int size);
    }
}
