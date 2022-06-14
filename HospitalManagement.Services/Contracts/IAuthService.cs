using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Dtos.Incoming.Auth;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface IAuthService
    {
        Task<AppUser> ValidateUser(LoginDto userDto);
        Task<string> CreateToken(AppUser user);
    }
}
