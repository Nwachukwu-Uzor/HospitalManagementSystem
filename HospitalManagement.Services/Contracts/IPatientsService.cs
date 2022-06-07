using HospitalManagement.Services.Dtos.Incoming.Patients;
using HospitalManagement.Services.Dtos.Outgoing.Patients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface IPatientsService
    {
        Task<PatientRequestDto> CreatePatientAsync(PatientCreationDto patientRegistrationDto);
        Task<IEnumerable<PatientRequestDto>> GetAllPatients(int page = 1, int pageSize = 50);
        Task<PatientRequestDto> GetPatientByIdentityNumberAsync(string patientIdentificationNumber);
    }
}
