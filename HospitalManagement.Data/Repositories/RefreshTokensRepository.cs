using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;

namespace HospitalManagement.Data.Repositories
{
    public class RefreshTokensRepository : GenericRepository<RefreshToken>, IRefreshTokensRepository
    {
        public RefreshTokensRepository(AppDbContext context) : base(context)
        {
        }
    }
}
