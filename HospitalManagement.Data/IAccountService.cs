using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public interface IAccountService
    {
        Task<IdentityUser> CreateUserAccountAsync(IdentityUser users, string password);
        Task<IdentityUser> SignInUserAsync(string email, string password);
    }
}
