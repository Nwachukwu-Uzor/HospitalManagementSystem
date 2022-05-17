using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class AccountService : IAccountService
    {
       private readonly UserManager<IdentityUser> _userManager;

        public AccountService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> CreateUserAccountAsync(IdentityUser user, string password)
        {
            var userExist = await _userManager.FindByEmailAsync(user.Email);

            if (userExist != null)
            {
                return userExist;
            }

            var isCreated = await _userManager.CreateAsync(user, password);

            if(!isCreated.Succeeded)
            {
                var errorMessage = new StringBuilder();
                foreach(var error in isCreated.Errors)
                {
                    errorMessage.AppendLine($" {error.Description}");
                }
                throw new ArgumentException($"Unable to create a user with the provided credentials {errorMessage.ToString().Trim()}");
            }

            return user;
        }

        public async Task<IdentityUser> SignInUserAsync(string email, string password)
        {
            var accountExists = await _userManager.FindByEmailAsync(email);

            if (accountExists == null)
            {
                throw new ArgumentException($"No user exists with the email account {email}");
            }

            var loginSucceeded = await _userManager.CheckPasswordAsync(accountExists, password);

            if (!loginSucceeded)
            {
                throw new ArgumentException("Incorrect password");
            }

            return accountExists;
        }
    }
}
