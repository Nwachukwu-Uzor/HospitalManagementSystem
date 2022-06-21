using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;

namespace HospitalManagementData.Repositories
{
    public class RefreshTokensRepository : GenericRepository<RefreshToken>, IRefreshTokensRepository
    {
        public RefreshTokensRepository(AppDbContext context) : base(context)
        {
        }
    }
}
