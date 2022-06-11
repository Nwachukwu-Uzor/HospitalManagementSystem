using HospitalManagement.Domain.Models;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Contracts
{
    public interface IUserRepository<T> : IGenericRepository<T> where T : AppUser
    {
        public Task<T> CreateAsync(T entity, string password);
        public Task<T> GetUserByIdentityNumber(string identityNumber);
        public Task<T> GetUserByEmail(string email);
    }
}
