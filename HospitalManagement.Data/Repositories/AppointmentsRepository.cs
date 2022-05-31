using HospitalManagement.Commons.Contracts;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
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
        public AppointmentsRepository(AppDbContext context, IDateTimeValidator dateTimeValidator) : base(context)
        {
            _dateTimeValidator = dateTimeValidator;
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
                    $"Dr. {appointment.Doctor.User.FirstName} {appointment.Doctor.User.LastName} already has to {_maxDailyAppointments} appointments"
                );
            }

            return await base.AddAsync(appointment);
        }
        public async override Task<IEnumerable<Appointment>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.Where(appoint => appoint.Status == 1).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                                .Include(app => app.Doctor)
                                .Include(app => app.Patient)
                                .OrderBy(app => app.CreatedAt).ToListAsync(); ;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(string doctorIdentityNumber, int pageSize, int pageNumber)
        {
            var appointments = await _dbSet.Where(app =>
                app.Doctor.IdentificationNumber == doctorIdentityNumber
                &&
                app.Status == 1
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
                &&
                app.Status == 1
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
                app.Status == 1
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
    }
}
