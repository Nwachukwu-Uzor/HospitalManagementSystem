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
        public AppointmentsRepository(AppDbContext context) : base(context)
        { }

        public override async Task<Appointment> AddAsync(Appointment appointment)
        {
            if (appointment.AppointmentDate < DateTime.Today)
            {
                throw new ArgumentException($"The appointment date can not be less than " +
                    $"{DateTime.Today.ToShortDateString()} at ${nameof(AddAsync)}"
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
            .OrderByDescending(app => app.CreatedAt)
            .Include(app => app.Doctor)
            .Include(app => app.Patient)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            if (appointments == null)
            {
                throw new ArgumentException($"No appointmentment match the patient id parameter {nameof(GetAppointmentsForPatientAsync)}");
            };

            return appointments;
        }
    }
}
