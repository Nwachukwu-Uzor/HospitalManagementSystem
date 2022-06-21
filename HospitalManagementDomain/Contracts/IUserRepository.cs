using HospitalManagementDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementDomain.Contracts
{
    public interface IUserRepository<T> : IGenericRepository<T> where T : AppUser
    {
        public Task<T> GetUserByIdentityNumber(string identityNumber);
        public Task<T> GetUserByEmail(string email);
        public Task<IEnumerable<T>> SearchForUsers(string name = "", string email = "", int page = 1, int size = 25);
    }
}
