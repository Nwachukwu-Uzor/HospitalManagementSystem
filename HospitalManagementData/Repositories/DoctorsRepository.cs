using HospitalManagementBL.Contracts;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HospitalManagementData.Repositories
{
    public class DoctorsRepository : BaseUserRepository<Doctor>, IDoctorsRepository
    {

        public DoctorsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator, UserManager<AppUser> userManager) 
        : base(context, identityNumberGenerator, "DCT", userManager)
        {
        }
    }
}
