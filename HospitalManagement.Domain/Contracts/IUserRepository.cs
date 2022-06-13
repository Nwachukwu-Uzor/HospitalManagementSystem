using HospitalManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Contracts
{
    public interface IUserRepository<T> : IGenericRepository<T> where T : AppUser
    {
        public Task<T> CreateAsync(T entity, string password, List<string> roles);
        public Task<T> GetUserByIdentityNumber(string identityNumber);
        public Task<T> GetUserByEmail(string email);
        public Task<IEnumerable<T>> SearchForUsers(string name = "", string email = "", int page = 1, int size = 25);
    }
}
