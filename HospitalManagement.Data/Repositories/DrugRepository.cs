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
    public class DrugRepository : GenericRepository<Drug>, IDrugRepository
    {
        private readonly IIdentityNumberGenerator _IdentityNumberGenerator;
        public DrugRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator) : base(context)
        {
            _IdentityNumberGenerator = identityNumberGenerator;
        }

        public override async Task<Drug> AddAsync(Drug drug)
        {
            var identityNumber = _IdentityNumberGenerator.GenerateIdNumber("DG");

            var drugExist = await GetDrugByIdentityNumber(identityNumber);

            if (drugExist != null)
            {
                return await AddAsync(drug);
            }
            return await base.AddAsync(drug);
        }

        public async Task<Drug> GetDrugByIdentityNumber(string identityNumber)
        {
            return await _dbSet.Where(drug => drug.IdentificationNumber == identityNumber && drug.Status == 1).FirstOrDefaultAsync();
        }
    }
}
