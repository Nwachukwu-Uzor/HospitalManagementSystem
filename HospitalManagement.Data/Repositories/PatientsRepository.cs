using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HospitalManagement.Data.Repositories
{
    public class PatientsRepository : BaseUserRepository<Patient>, IPatientsRepository
    {
        public PatientsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator, UserManager<AppUser> userManager)
        : base(context, identityNumberGenerator, "PT", userManager, new List<string> { "Patient" })
        {
        }
    }  
}
