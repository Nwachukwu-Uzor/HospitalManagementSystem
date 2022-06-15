using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Repositories
{
    public class StaffRepository : BaseUserRepository<Staff>, IStaffRepository<Staff>
    {
        public StaffRepository(
            AppDbContext context, IIdentityNumberGenerator identityNumberGenerator,
            UserManager<AppUser> userManager
        ) : base(context, identityNumberGenerator, "STF", userManager)
        {
        }

        public async Task<IEnumerable<Staff>> GetStaffForDepartment(string departmentNumber, int page, int size)
        {
            return await _dbSet.Where(st => st.DepartmentNumber == departmentNumber).OrderByDescending(st => st.FirstName).Skip((page - 1) * page).ToListAsync();
        }
    }
}
