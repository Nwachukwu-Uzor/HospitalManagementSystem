using HospitalManagementDomain.Models;
using HospitalManagementServices.Dtos.Incoming.Auth;
using System.Threading.Tasks;

namespace HospitalManagementServices.Contracts
{
    public interface IAuthService
    {
        Task<AppUser> ValidateUser(LoginDto userDto);
        Task<string> CreateToken(AppUser user);
    }
}
