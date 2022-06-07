using HospitalManagement.Domain.Models;
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
        Task<AppUser> CreateUserAccountAsync(AppUser users, string password);
        Task<AppUser> SignInUserAsync(string email, string password);
    }
}
