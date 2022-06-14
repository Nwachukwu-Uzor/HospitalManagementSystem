using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;

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
    }
}
