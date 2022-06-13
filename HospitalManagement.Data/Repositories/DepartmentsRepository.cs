using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Repositories
{
    public class DepartmentsRepository : GenericRepository<Department>, IDepartmentsRepository
    {
        public DepartmentsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Department> GetDepartmentByNumber(string departmentNumber)
        {
            return await _dbSet.Where(dept => dept.DepartmentNumber == departmentNumber).FirstOrDefaultAsync();
        }
    }
}
