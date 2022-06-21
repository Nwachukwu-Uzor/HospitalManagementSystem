using HospitalManagementServices.Dtos.Outgoing.Staff;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementServices.Contracts
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffRequestDto>> GetAllStaff(int page, int size);
        Task<StaffRequestDto> GetStaffByIdentityNumber(string identityNumber);
        Task<IEnumerable<StaffRequestDto>> SearchForStaffByNameOrEmail(string name = "", string email = "", int page = 1, int size = 25);
    }
}
