using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
using HospitalManagement.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Repositories
{
    public class DoctorsRepository : GenericRepository<Doctor>, IDoctorsRepository
    {
        private readonly IIdentityNumberGenerator _identityNumberGenerator;
        public DoctorsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator) : base(context)
        {
            _identityNumberGenerator = identityNumberGenerator;
        }

        public override async Task<Doctor> AddAsync(Doctor entity)
        {
            var randomId = _identityNumberGenerator.GenerateIdNumber("DCT");

            var doesDoctorExist = await GetDoctorByIdentityNumber(randomId);


            // Develop a more efficient way to ensure the identity number is unique
            if (doesDoctorExist != null)
            {
                return await AddAsync(entity);
            }

            var doctorByEmail = await _dbSet.Where(doct => doct.Email == entity.Email).FirstOrDefaultAsync();

            if (doctorByEmail != null)
            {
                throw new ArgumentException("A doctor exists with the email provided");
            }

            entity.IdentificationNumber = randomId;

            return await base.AddAsync(entity);
        }

        public Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(Guid doctorId, int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetDailyAppointmentsForDoctorAsync(Guid doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> GetDoctorByIdentityNumber(string identityNumber)
        {
           return await _dbSet.Where(doctor => doctor.IdentificationNumber == identityNumber).FirstOrDefaultAsync();
        }
    }
}
