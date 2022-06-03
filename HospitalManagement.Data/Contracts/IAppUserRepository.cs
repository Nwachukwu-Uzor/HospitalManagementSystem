using HospitalManagement.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Contracts
{
    public interface IAppUserRepository
    {
        Task<AppUser> RegisterUser(AppUser user);
        Task<AppUser> FindUserByEmail(string email);
        Task<AppUser> LoginUser(string email, string password);
        Task<AppUser> FindUserByIdentificationNumber(string identificationNumber);
        Task<IEnumerable<AppUser>> GetAllDoctors(int page, int size);
        Task<IEnumerable<AppUser>> GetAllPatientsPaginated(int page, int size);
    }
}
