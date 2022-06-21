using HospitalManagementDomain.Models;
using HospitalManagementServices.Contracts;
using HospitalManagementServices.Dtos.Incoming.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly string _jwtKey;

        public AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var signInCredentials = GetSignInCredentials();
            var claims = await GetClaims(user);
            var token = GenerateTokenOptions(signInCredentials, claims);

            // serialize the jwt token into a string and return it
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signInCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");

            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));

            // create a token using options provided in the parameter
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signInCredentials
            );

            return token;
        }

        private async Task<List<Claim>> GetClaims(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSignInCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            // in production
            // var Key = Environment.GetEnvironmentVariable("JWT_KEY")
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        public async Task<AppUser> ValidateUser(LoginDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);

            if (user == null)
            {
                return user;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, userDto.Password);

            if (!isPasswordValid)
            {
                return null;
            }

            return user;
        }
    }
}
