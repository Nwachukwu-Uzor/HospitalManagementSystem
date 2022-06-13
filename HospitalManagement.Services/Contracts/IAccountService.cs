using HospitalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface IAccountService
    {
        Task<bool> CreateAccount(AppUser user, List<string> roles);
        Task<bool> LoginAccount(string email, string password);
    }
}
