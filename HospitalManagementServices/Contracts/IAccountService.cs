using HospitalManagementServices.Dtos.Incoming.Doctors;
using HospitalManagementServices.Dtos.Incoming.Patients;
using HospitalManagementServices.Dtos.Incoming.Staff;
using HospitalManagementServices.Dtos.Outgoing.Doctors;
using HospitalManagementServices.Dtos.Outgoing.Patients;
using HospitalManagementServices.Dtos.Outgoing.Staff;
using System.Threading.Tasks;

namespace HospitalManagementServices.Contracts
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
