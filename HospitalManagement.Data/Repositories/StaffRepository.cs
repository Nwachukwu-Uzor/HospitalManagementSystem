using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Repositories
{
    public class StaffRepository : BaseUserRepository<Staff>, IStaffRepository<Staff>
    {
        public StaffRepository(
            AppDbContext context, IIdentityNumberGenerator identityNumberGenerator,
            UserManager<AppUser> userManager
        ) : base(context, identityNumberGenerator, "STF", userManager, new List<string> { "staff"})
        {
        }
    }
}
