using AutoMapper;
using Hangfire;
using HospitalManagementBL.Contracts;
using HospitalManagementBL.Models;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using HospitalManagementServices.Contracts;
using HospitalManagementServices.Dtos.Incoming.Appointment;
using HospitalManagementServices.Dtos.Outgoing.Appointment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementServices
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly IDateTimeValidator _dateTimeValidator;

        public AppointmentsService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ISmsService smsService, IDateTimeValidator dateTimeValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _smsService = smsService;
            _dateTimeValidator = dateTimeValidator;
        }
        public async Task<AppointmentRequestDto> CreateAppointment(AppointmentCreationDto appointmentCreationDto)
        {
            try
            {
                var patient = await _unitOfWork.Patients.GetUserByIdentityNumber(appointmentCreationDto.PatientIdentityNumber);

                if (patient == null)
                {
                    throw new ArgumentException("The patient identification number provided is invalid");
                }

                var doctor = await _unitOfWork.Doctors.GetUserByIdentityNumber(appointmentCreationDto.DoctorIdentityNumber);

                if (doctor == null)
                {
                    throw new ArgumentException("The doctor identification number provided is invalid");
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

                return _mapper.Map<AppointmentRequestDto>(appointmentAdded);
            } catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            
        }

        public async Task<IEnumerable<AppointmentRequestDto>> GetAllAppointmentsAsync(int page = 1, int pageSize = 50)
        {
            try
            {
                var appointments = await _unitOfWork.Appointments.GetAllPaginatedAsync(page, pageSize, new List<string> { "Doctor", "Patient" });
                return _mapper.Map<IEnumerable<AppointmentRequestDto>>(appointments);
            } catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
          
        }

        public async Task<IEnumerable<AppointmentRequestDto>> GetAppointmentByDoctorIdAsync(string doctorIdentificationNumber, int pageSize = 10, int pageNumber = 1)
        {
           try
            {
                var appointments = await _unitOfWork.Appointments.GetAppointmentsForDoctorAsync(doctorIdentificationNumber, pageSize, pageNumber);

                if (appointments == null)
                {
                    throw new ArgumentException("Unable to get an appointment with the id supplied");
                }

                return _mapper.Map<IEnumerable<AppointmentRequestDto>>(appointments);
            } catch(Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<AppointmentRequestDto> GetAppointmentById(Guid appointmentId)
        {
            try
            {
                var appointments = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);

                if (appointments == null)
                {
                    throw new ArgumentException("Unable to get an appointment with the id supplied");
                }

                return _mapper.Map<AppointmentRequestDto>(appointments);
            } catch(Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
         
        }

        public async Task<IEnumerable<AppointmentRequestDto>> GetAppointmentByPatientIdAsync(string patientIdentificationNumber, int pageSize = 10, int pageNumber = 1)
        {
            try
            {
                var appointments = await _unitOfWork.Appointments.GetAppointmentsForDoctorAsync(patientIdentificationNumber, pageSize, pageNumber);

                if (appointments == null)
                {
                    throw new ArgumentException("Unable to get an appointment with the id supplied");
                }

                return _mapper.Map<IEnumerable<AppointmentRequestDto>>(appointments);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
