using HospitalManagement.Api.Response;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Patients;
using HospitalManagement.Services.Dtos.Outgoing.Patients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class PatientsController : BaseController
    {
        private readonly IPatientsService _patientsService;
        public PatientsController(IPatientsService patientsService) : base()
        {
            _patientsService = patientsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRequestDto>>> GetAllPatients(int page = 1, int pageSize = 50)
        {
            try
            {
                var patients = await _patientsService.GetAllPatients(page, pageSize);
                

                return Ok(GenerateApiResponse<IEnumerable<PatientRequestDto>>.GenerateSuccessResponse(patients));
            } catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<IEnumerable<PatientRequestDto>>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpGet("{patientIdentificationNumber}", Name = nameof(GetPatientByIdentityNumberAsync))]
        public async Task<ActionResult<PatientRequestDto>> GetPatientByIdentityNumberAsync(string patientIdentificationNumber)
        {
            try
            {
                var patient = await _patientsService.GetPatientByIdentityNumberAsync(patientIdentificationNumber);

                return Ok(GenerateApiResponse<PatientRequestDto>.GenerateSuccessResponse(patient));
            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<PatientRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }
    }
}
