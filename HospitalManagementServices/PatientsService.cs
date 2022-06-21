using AutoMapper;
using HospitalManagementBL.Contracts;
using HospitalManagementData;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using HospitalManagementServices.Contracts;
using HospitalManagementServices.Dtos.Incoming.Patients;
using HospitalManagementServices.Dtos.Outgoing.Patients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementServices
{
    public class PatientsService : IPatientsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PatientRequestDto>> GetAllPatients(int page = 1, int pageSize = 50)
        {
            var patients = await _unitOfWork.Patients.GetAllPaginatedAsync(page, pageSize);
            return _mapper.Map<IEnumerable<PatientRequestDto>>(patients);
        }

        public async Task<PatientRequestDto> GetPatientByIdentityNumberAsync(string patientIdentificationNumber)
        {
            try
            {
                var patient = await _unitOfWork.Patients.GetUserByIdentityNumber(patientIdentificationNumber);

                if (patient == null)
                {
                    throw new ArgumentException("No patient with the specified identity number, please supply a valid identity number");
                }

                return _mapper.Map<PatientRequestDto>(patient);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
