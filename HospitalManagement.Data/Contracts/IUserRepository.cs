using HospitalManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Contracts
{
    public interface IUserRepository<T> : IGenericRepository<T> where T : AppUser
    {
        public Task<T> GetUserByIdentityNumber(string identityNumber);
        public Task<T> GetUserByEmail(string email);
    }
}
