using HospitalManagementBL.Contracts;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HospitalManagementData.Repositories
{
    public class PatientsRepository : BaseUserRepository<Patient>, IPatientsRepository
    {
        public PatientsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator, UserManager<AppUser> userManager)
        : base(context, identityNumberGenerator, "PT", userManager)
        {
        }
    }  
}
