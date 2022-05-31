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
    public class PatientsRepository : GenericRepository<Patient>, IPatientsRepository
    {
        private readonly IIdentityNumberGenerator _identityNumberGenerator;
        public PatientsRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator) : base(context)
        {
            _identityNumberGenerator = identityNumberGenerator;
        }

        public override async Task<IEnumerable<Patient>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.Where(entity => entity.Status == 1).Include(patient => patient.User).Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderBy(pat => pat.CreatedAt).ToListAsync();
        }

        public override async Task<Patient> GetByIdAsync(Guid id)
        {
            return await _dbSet.Where(entity => entity.Id == id && entity.Status == 1).Include(patient => patient.User).FirstOrDefaultAsync();
        }

        public override async Task<Patient> AddAsync(Patient entity)
        {
            var randomId = _identityNumberGenerator.GenerateIdNumber("PT");

            var patientExists = await GetPatientByIdentityNumber(randomId);

            if (patientExists != null)
            {
                return await AddAsync(entity);
            }

            var patientByEmail = await _dbSet.Where(patient => patient.User.Email == entity.User.Email).FirstOrDefaultAsync();

            if (patientByEmail != null)
            {
                throw new ArgumentException("A patient exists with the email provided");
            }

            entity.IdentificationNumber = randomId;

            return await base.AddAsync(entity);
        }

        public async Task<Patient> GetPatientByIdentityNumber(string identityNumber)
        {
            return await _dbSet.Where(patient => 
                patient.IdentificationNumber == identityNumber 
                && 
                patient.Status == 1
            ).FirstOrDefaultAsync();
        }
    }
}
