using HospitalManagement.Api.Response;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Appointment;
using HospitalManagement.Services.Dtos.Outgoing.Appointment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentsService _appointmentsService;
        public AppointmentsController(IAppointmentsService appointmentsService) : base()
        {
            _appointmentsService = appointmentsService;
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentRequestDto>> CreateAppointment
            (AppointmentCreationDto appointmentCreationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(
                        GenerateApiResponse<AppointmentRequestDto>
                            .GenerateFailureResponse("Invalid information to create appointment")
                    );
                }

                var appointmentAdded = await _appointmentsService.CreateAppointment(appointmentCreationDto);

                return CreatedAtRoute(
                    nameof(GetAppointmentById), 
                    new { appointmentId = appointmentAdded.Id },
                     GenerateApiResponse<AppointmentRequestDto>
                        .GenerateSuccessResponse(appointmentAdded)
                );
            } catch(Exception ex)
            {
                return BadRequest(
                    GenerateApiResponse<AppointmentRequestDto>
                        .GenerateFailureResponse(ex.Message)
                );
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentRequestDto>>> GetAllAppointmentsAsync(int page = 1, int pageSize = 50)
        {
            try
            {
                var appointments = await _appointmentsService.GetAllAppointmentsAsync(page, pageSize);
                return Ok(
                    GenerateApiResponse<IEnumerable<AppointmentRequestDto>>
                        .GenerateSuccessResponse(appointments)
                );
            } catch(Exception ex)
            {
                return BadRequest(
                    GenerateApiResponse<AppointmentRequestDto>
                        .GenerateFailureResponse(ex.Message)
                    );
            }
        }

        [HttpGet("{appointmentId:Guid}", Name = nameof(GetAppointmentById))]
        public async Task<ActionResult<AppointmentRequestDto>> GetAppointmentById(Guid appointmentId)
        {
            try
            {
                var appointment = await _appointmentsService.GetAppointmentById(appointmentId);

                return Ok(
                    GenerateApiResponse<AppointmentRequestDto>
                        .GenerateSuccessResponse(appointment)
                );
            } catch(Exception ex)
            {
                return NotFound(
                    GenerateApiResponse<AppointmentRequestDto>
                        .GenerateFailureResponse(ex.Message)
                );
            }
        }

        [HttpGet("doctors/{doctorIdentificationNumber}")]
        public async Task<ActionResult<IEnumerable<AppointmentRequestDto>>> GetAppointmentByDoctorIdAsync(
            string doctorIdentificationNumber, int pageSize=10, int pageNumber=1
        )
        {
            try
            {
                var appointments = await _appointmentsService.GetAppointmentByDoctorIdAsync(doctorIdentificationNumber, pageSize, pageNumber);

                return Ok(
                    GenerateApiResponse<IEnumerable<AppointmentRequestDto>>
                        .GenerateSuccessResponse(appointments)
                    );
            } catch(Exception ex)
            {
                return NotFound(
                    GenerateApiResponse<AppointmentRequestDto>
                        .GenerateFailureResponse(ex.Message)
                );
            }
        }
         
        [HttpGet("patients/{patientIdentificationNumber}")]
        public async Task<ActionResult<IEnumerable<AppointmentRequestDto>>> GetAppointmentByPatientIdAsync(
            string patientIdentificationNumber, int pageSize=10, int pageNumber=1
        )
        {
            try
            {
                var appointments = await _appointmentsService.GetAppointmentByDoctorIdAsync(patientIdentificationNumber, pageSize, pageNumber);

                return Ok(
                    GenerateApiResponse<IEnumerable<AppointmentRequestDto>>
                        .GenerateSuccessResponse(appointments)
                    );
            } catch(Exception ex)
            {
                return NotFound(
                    GenerateApiResponse<AppointmentRequestDto>
                        .GenerateFailureResponse(ex.Message)
                );
            }
        }
    }
}
