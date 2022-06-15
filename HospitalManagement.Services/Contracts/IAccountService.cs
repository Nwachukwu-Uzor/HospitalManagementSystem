using HospitalManagement.Services.Dtos.Incoming.Doctors;
using HospitalManagement.Services.Dtos.Incoming.Patients;
using HospitalManagement.Services.Dtos.Incoming.Staff;
using HospitalManagement.Services.Dtos.Outgoing.Doctors;
using HospitalManagement.Services.Dtos.Outgoing.Patients;
using HospitalManagement.Services.Dtos.Outgoing.Staff;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface IAccountService
    {
        Task<DoctorRequestDto> RegisterNewDoctor(DoctorCreationDto doctor);
        Task<PatientRequestDto> RegisterNewPatient(PatientCreationDto patient);
        Task<StaffRequestDto> RegisterNewStaff(StaffCreationDto staff);
        Task<bool> LoginAccount(string email, string password);
        Task<bool> DeleteAccount(string email);
        Task<bool> MakeStaffAdmin(StaffAdminDto staffDto);
    }
}
