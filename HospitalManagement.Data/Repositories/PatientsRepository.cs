using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;

namespace HospitalManagement.Data.Repositories
{
    public class PatientsRepository : BaseUserRepository<Patient>, IPatientsRepository
    {
        public PatientsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator)
        : base(context, identityNumberGenerator, "PT")
        {
        }

    }  
}
