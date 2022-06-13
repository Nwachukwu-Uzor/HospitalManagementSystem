using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class AccountService : IAccountService
    {
        public Task<bool> CreateAccount(AppUser user, List<string> roles)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginAccount(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
