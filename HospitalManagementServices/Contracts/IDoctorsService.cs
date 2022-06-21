using HospitalManagementServices.Dtos.Incoming.Doctors;
using HospitalManagementServices.Dtos.Outgoing.Doctors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementServices.Contracts
{
    public interface IDoctorsService 
    {
        Task<IEnumerable<DoctorRequestDto>> GetAllDoctorsAsync(int pageNumber = 1, int pageSize = 50);
        Task<DoctorRequestDto> GetDoctorByIdentityNumberAsync(string doctorIdentityNumber);
        Task<IEnumerable<DoctorRequestDto>> SearchForDoctor(string name = "", string email = "", int page = 1, int size = 25);
    }
}
