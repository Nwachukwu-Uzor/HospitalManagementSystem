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

        public override async Task<IEnumerable<Doctor>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.Where(entity => entity.Status == 1).Include(doct => doct.User).Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderBy(pat => pat.CreatedAt).ToListAsync();
        }

        public override async Task<Doctor> GetByIdAsync(Guid id)
        {
            return await _dbSet.Where(entity => entity.Id == id && entity.Status == 1).Include(doct => doct.User).FirstOrDefaultAsync();
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

            var doctorByEmail = await _dbSet.Where(doct => doct.User.Email == entity.User.Email).FirstOrDefaultAsync();

            if (doctorByEmail != null)
            {
                throw new ArgumentException("A doctor exists with the email provided");
            }

            entity.IdentificationNumber = randomId;

            return await base.AddAsync(entity);
        }


        public async Task<Doctor> GetDoctorByIdentityNumber(string identityNumber)
        {
           return await _dbSet.Where(doctor => doctor.IdentificationNumber == identityNumber).FirstOrDefaultAsync();
        }
    }
}
