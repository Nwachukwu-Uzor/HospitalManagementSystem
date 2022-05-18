﻿using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
using HospitalManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class AppointmentsController : BaseController
    {
        public AppointmentsController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService)
            : base (unitOfWork, mapper, accountService, emailService)
        {

        }

        [HttpPost]
        public async Task<IActionResult> CreateAppoint(AppointmentCreationDto appointmentCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid information to create appointment");
            }
            try
            {
                var patient = await _unitOfWork.Patients.GetPatientByIdentityNumber(appointmentCreationDto.PatientIdentityNumber);

                if (patient == null)
                {
                    return BadRequest("The patient identification number provided is invalid");
                }

                var doctor = await _unitOfWork.Doctors.GetDoctorByIdentityNumber(appointmentCreationDto.DoctorIdentityNumber);

                if (doctor == null)
                {
                    return BadRequest("The doctor identification number provided is invalid");
                }

                var appointment = _mapper.Map<Appointment>(appointmentCreationDto);

                appointment.Doctor = doctor;
                appointment.Patient = patient;

                var appointmentAdded = await _unitOfWork.Appointments.AddAsync(appointment);

                // return Ok(_mapper.Map<AppointmentRequestDto>(appointmentAdded));
                return CreatedAtRoute(
                    nameof(GetAppointmentById), 
                    new { appointmentId = appointmentAdded.Id }, 
                    _mapper.Map<AppointmentRequestDto>(appointmentAdded)
                );
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentsAsync(int page = 1, int pageSize = 50)
        {
            try
            {
                var appointments = await _unitOfWork.Appointments.GetAllPaginatedAsync(page, pageSize);
                return Ok(_mapper.Map<IEnumerable<AppointmentRequestDto>>(appointments));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{appointmentId:Guid}", Name = nameof(GetAppointmentById))]
        public async Task<IActionResult> GetAppointmentById(Guid appointmentId)
        {
            try
            {
                var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);

                if (appointment == null)
                {
                    return NotFound("Unable to get an appointment with the id supplied");
                }

                return Ok(_mapper.Map<AppointmentRequestDto>(appointment));
            } catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}