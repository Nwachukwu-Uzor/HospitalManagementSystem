using HospitalManagement.BL.Contracts;
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
        protected readonly IIdentityNumberGenerator _identityNumberGenerator;
        public DepartmentsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator) : base(context)
        {
            _identityNumberGenerator = identityNumberGenerator;
        }

        public async Task<Department> CreateAsync(Department department)
        {
            var deptNumber = _identityNumberGenerator.GenerateIdNumber(department.DepartmentInitials);

            var deptExist = await GetDepartmentByNumber(deptNumber);

            if (deptExist != null)
            {
                return await CreateAsync(department);
            }

            department.DepartmentNumber = deptNumber;

            await _dbSet.AddAsync(department);

            return (await _context.SaveChangesAsync() > 0) ? department : null;
        }

        public async Task<Department> GetDepartmentByNumber(string departmentNumber)
        {
            return await _dbSet.Where(dept => dept.DepartmentNumber == departmentNumber).FirstOrDefaultAsync();
        }
    }
}
