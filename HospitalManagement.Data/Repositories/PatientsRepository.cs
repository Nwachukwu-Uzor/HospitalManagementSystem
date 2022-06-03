using HospitalManagement.Commons.Contracts;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;

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
