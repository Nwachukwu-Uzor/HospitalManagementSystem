using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Repositories
{
    public class AppointmentsRepository : GenericRepository<Appointment>, IAppointmentsRepository
    {
        private readonly int _maxDailyAppointments = 3;

        private readonly IDateTimeValidator _dateTimeValidator;
        private readonly IIdentityNumberGenerator _identityNumberGenerator;

        public AppointmentsRepository(
            AppDbContext context, 
            IDateTimeValidator dateTimeValidator,
            IIdentityNumberGenerator identityNumberGenerator
        ) 
        : base(context)
        {
            _dateTimeValidator = dateTimeValidator;
            _identityNumberGenerator = identityNumberGenerator;
        }

        public override async Task<Appointment> AddAsync(Appointment appointment)
        {
            if (appointment.AppointmentDate < DateTime.Today)
            {
                throw new ArgumentException($"The appointment date can not be less than " +
                    $"{DateTime.Today.ToShortDateString()} {appointment.AppointmentDate.ToShortDateString()} at {nameof(AddAsync)}"
                );
            }

            var validated = _dateTimeValidator.Validate(appointment.AppointmentDate);

            if (!validated)
            {
                throw new ArgumentNullException("Appointment date must be between 7:30am and 6:00pm");
            }

            var appointments = await GetDailyAppointmentsForDoctorAsync(appointment.Doctor.IdentificationNumber, appointment.AppointmentDate);

            if (appointments.Count() >= _maxDailyAppointments)
            {
                throw new ArgumentException(
                    $"Dr. {appointment.Doctor.FirstName} {appointment.Doctor.LastName} already has to {_maxDailyAppointments} appointments"
                );
            }

            var referenceNumber = _identityNumberGenerator.GenerateIdNumber("AP", 20);

            appointment.ReferenceNumber = referenceNumber;

            return await base.AddAsync(appointment);
        }
        //public async override Task<IEnumerable<Appointment>> GetAllPaginatedAsync(int pageNumber, int pageSize, new List<)
        //{
        //    return await _dbSet.Where(appoint => appoint.Status == 1).Skip((pageNumber - 1) * pageSize).Take(pageSize)
        //                        .Include(app => app.Doctor)
        //                        .Include(app => app.Patient)
        //                        .OrderBy(app => app.CreatedAt).ToListAsync(); ;
        //}

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(string doctorIdentityNumber, int pageSize, int pageNumber)
        {
            var appointments = await _dbSet.Where(app =>
                app.Doctor.IdentificationNumber == doctorIdentityNumber
            )
            .AsNoTracking()
            .OrderByDescending(app => app.CreatedAt)
            .Include(app => app.Doctor)
            .Include(app => app.Patient)
            .Skip((pageNumber -1) * pageSize)
            .Take(pageSize)
            .OrderByDescending(appointment => appointment.CreatedAt)
            .ToListAsync();

            if (appointments == null)
            {
                throw new ArgumentException($"No appointmentment match the doctor id parameter {nameof(GetAppointmentsForDoctorAsync)}");
            };

            return appointments;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(string patientIdentityNumber, int pageSize, int pageNumber)
        {
            var appointments = await _dbSet.Where(app =>
                app.Patient.IdentificationNumber == patientIdentityNumber
            )
            .AsNoTracking()
            .Include(app => app.Doctor)
            .Include(app => app.Patient)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .OrderByDescending(app => app.CreatedAt)
            .ToListAsync();

            if (appointments == null)
            {
                throw new ArgumentException($"No appointmentment match the patient id parameter {nameof(GetAppointmentsForPatientAsync)}");
            };

            return appointments;
        }

        public async Task<IEnumerable<Appointment>> GetDailyAppointmentsForDoctorAsync(string doctorIdentityNumber, DateTime date)
        {
            var appointments = await _dbSet.Where(app =>
                app.Doctor.IdentificationNumber == doctorIdentityNumber
                &&
                app.AppointmentDate.DayOfYear == date.DayOfYear
                &&
                app.AppointmentDate.Year == date.Year
            )
            .AsNoTracking()
            .Include(app => app.Doctor)
            .Include(app => app.Patient)
            .OrderByDescending(appointment => appointment.CreatedAt)
            .ToListAsync();

            if (appointments == null)
            {
                throw new ArgumentException($"No appointmentment match the doctor id parameter {nameof(GetAppointmentsForDoctorAsync)}");
            };

            return appointments;
        }

        Task<IEnumerable<Appointment>> IAppointmentsRepository.GetAppointmentsForDoctorAsync(string doctorIdentityNumber, int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Appointment>> IAppointmentsRepository.GetAppointmentsForPatientAsync(string patientIdentityNumber, int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForTheNextDay()
        {
            return await _dbSet.Where(app => 
                app.AppointmentDate.DayOfYear == DateTime.UtcNow.AddDays(1).DayOfYear
                &&
                app.AppointmentDate.Year == DateTime.UtcNow.Year
            )
            .Include(app => app.Doctor)
            .Include(app => app.Patient)
            .OrderBy(app => app.AppointmentDate).ToListAsync();
        }

        Task<IEnumerable<Appointment>> IAppointmentsRepository.GetDailyAppointmentsForDoctorAsync(string doctorIdentityNumber, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
