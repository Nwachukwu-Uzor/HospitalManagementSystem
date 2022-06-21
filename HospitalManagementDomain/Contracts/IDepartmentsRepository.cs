using HospitalManagementDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementDomain.Contracts
{
    public interface IDepartmentsRepository : IGenericRepository<Department>
    {
        Task<Department> CreateAsync(Department department);
        Task<Department> GetDepartmentByNumber(string departmentNumber);
    }
}
