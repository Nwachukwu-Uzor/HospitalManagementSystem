using HospitalManagementServices.Dtos.Incoming.Patients;
using HospitalManagementServices.Dtos.Outgoing.Patients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementServices.Contracts
{
    public interface IPatientsService
    {
        Task<IEnumerable<PatientRequestDto>> GetAllPatients(int page = 1, int pageSize = 50);
        Task<PatientRequestDto> GetPatientByIdentityNumberAsync(string patientIdentificationNumber);
    }
}
