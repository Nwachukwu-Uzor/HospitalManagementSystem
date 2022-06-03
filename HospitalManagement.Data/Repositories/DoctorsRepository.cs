using HospitalManagement.Commons.Contracts;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
namespace HospitalManagement.Data.Repositories
{
    public class DoctorsRepository : BaseUserRepository<Doctor>, IDoctorsRepository
    {
        public DoctorsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator) 
        : base(context, identityNumberGenerator, "DCT")
        {
        }
    }
}
