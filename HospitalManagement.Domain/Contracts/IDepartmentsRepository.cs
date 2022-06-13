using HospitalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Contracts
{
    public interface IDepartmentsRepository : IGenericRepository<Department>
    {
        Task<Department> GetDepartmentByNumber(string departmentNumber);
    }
}
