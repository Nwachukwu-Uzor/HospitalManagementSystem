﻿using HospitalManagement.Services.Dtos.Incoming.Appointment;
using HospitalManagement.Services.Dtos.Outgoing.Appointment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface IAppointmentService
    {
        Task<AppointmentRequestDto> CreateAppointment(AppointmentCreationDto appointmentCreationDto);
        Task<IEnumerable<AppointmentRequestDto>> GetAllAppointmentsAsync(int page = 1, int pageSize = 50);
        Task<AppointmentRequestDto> GetAppointmentById(Guid appointmentId);
        Task<IEnumerable<AppointmentRequestDto>> GetAppointmentByDoctorIdAsync
            (string doctorIdentificationNumber, int pageSize = 10, int pageNumber = 1);
        Task<IEnumerable<AppointmentRequestDto>> GetAppointmentByPatientIdAsync(
            string patientIdentificationNumber, int pageSize = 10, int pageNumber = 1
        );
    }
}
