using HospitalManagementBL.Contracts;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementData.Repositories
{
    public class DepartmentsRepository : GenericRepository<Department>, IDepartmentsRepository
    {
        protected readonly IIdentityNumberGenerator _identityNumberGenerator;
        private readonly DbSet<Staff> _staffSet;
        public DepartmentsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator) : base(context)
        {
            _identityNumberGenerator = identityNumberGenerator;
            _staffSet = context.Staff;
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
