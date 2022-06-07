using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;

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
