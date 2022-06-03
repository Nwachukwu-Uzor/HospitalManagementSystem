using AutoMapper;
using Hangfire;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Api.Response;
using HospitalManagement.Commons.Contracts;
using HospitalManagement.Commons.Models;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class AppointmentsController : BaseController
    {
        private readonly IDateTimeValidator _dateTimeValidator;
        public AppointmentsController(
            IUnitOfWork unitOfWork, IMapper mapper, 
            IAccountService accountService, 
            IEmailService emailService, 
            ISmsService smsService,
            IDateTimeValidator dateTimeValidator
        )
            : base (unitOfWork, mapper, accountService, emailService, smsService)
        {
            _dateTimeValidator = dateTimeValidator;
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

                var patient = await _unitOfWork.Patients.GetUserByIdentityNumber(appointmentCreationDto.PatientIdentityNumber);

                if (patient == null)
                {
                    return BadRequest(
                        GenerateApiResponse<AppointmentRequestDto>
                        .GenerateFailureResponse("The patient identification number provided is invalid")
                    );
                }

                var doctor = await _unitOfWork.Doctors.GetUserByIdentityNumber(appointmentCreationDto.DoctorIdentityNumber);

                if (doctor == null)
                {
                    return BadRequest(GenerateApiResponse<AppointmentRequestDto>
                        .GenerateFailureResponse("The doctor identification number provided is invalid")
                    );
                }

                var appointment = _mapper.Map<Appointment>(appointmentCreationDto);

                appointment.Doctor = doctor;
                appointment.Patient = patient;

                var appointmentAdded = await _unitOfWork.Appointments.AddAsync(appointment);

                var doctorName = $"{doctor.FirstName} {doctor.LastName}";

                var appointmentDate = appointmentAdded.AppointmentDate.ToShortDateString();
                var alertDate = $"Tomorrow at {appointmentAdded.AppointmentDate.TimeOfDay}";

                // var emailToSend = _emailService.GenerateAppointmentEmail(patient.Email, doctorName, doctor.IdentificationNumber, appointmentDate);
                var alertEmail = _emailService.GenerateAppointmentEmail(patient.Email, doctorName, doctor.IdentificationNumber, alertDate);

                var alertTime = _dateTimeValidator.GenerateAlertDate(appointmentAdded.AppointmentDate);


                var smsToSend = new SMS() { Body = $"Dear {patient.FirstName}, you have an appointment on {appointmentDate}" };

                var jobId = BackgroundJob.Schedule(() => _emailService.SendMail(alertEmail), alertTime);
                // var isEmailSent = await _emailService.SendMail(emailToSend);
                return CreatedAtRoute(
                    nameof(GetAppointmentById), 
                    new { appointmentId = appointmentAdded.Id },
                     GenerateApiResponse<AppointmentRequestDto>
                        .GenerateSuccessResponse(_mapper.Map<AppointmentRequestDto>(appointmentAdded))
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
                var appointments = await _unitOfWork.Appointments.GetAllPaginatedAsync(page, pageSize);
                Response.Headers.Add("page", page.ToString());
                return Ok(
                    GenerateApiResponse<IEnumerable<AppointmentRequestDto>>
                        .GenerateSuccessResponse(_mapper.Map<IEnumerable<AppointmentRequestDto>>(appointments))
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
                var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);

                if (appointment == null)
                {
                    return NotFound(
                        GenerateApiResponse<AppointmentRequestDto>
                            .GenerateFailureResponse("Unable to get an appointment with the id supplied")
                    );
                }

                return Ok(
                    GenerateApiResponse<AppointmentRequestDto>
                        .GenerateSuccessResponse(_mapper.Map<AppointmentRequestDto>(appointment))
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
                var appointments = await _unitOfWork.Appointments.GetAppointmentsForDoctorAsync(doctorIdentificationNumber, pageSize, pageNumber);

                return Ok(
                    GenerateApiResponse<IEnumerable<AppointmentRequestDto>>
                        .GenerateSuccessResponse(_mapper.Map<IEnumerable<AppointmentRequestDto>>(appointments))
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
                var appointments = await _unitOfWork.Appointments.GetAppointmentsForPatientAsync(patientIdentificationNumber, pageSize, pageNumber);

                return Ok(
                    GenerateApiResponse<IEnumerable<AppointmentRequestDto>>
                        .GenerateSuccessResponse(_mapper.Map<IEnumerable<AppointmentRequestDto>>(appointments))
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
