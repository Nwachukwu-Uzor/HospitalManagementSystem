using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Data.Repositories
{
    public class DoctorsRepository : BaseUserRepository<Doctor>, IDoctorsRepository
    {
        public DoctorsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator, UserManager<AppUser> userManager) 
        : base(context, identityNumberGenerator, "DCT", userManager)
        {
        }
    }
}
