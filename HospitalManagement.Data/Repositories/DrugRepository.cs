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

        public override async Task<IEnumerable<Drug>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.Where(entity => entity.Status == 1).Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderBy(drug => drug.Name).ToListAsync();
        }

        public override async Task<Drug> AddAsync(Drug drug)
        {
            var identityNumber = _IdentityNumberGenerator.GenerateIdNumber("DG");

            var drugExist = await GetDrugByIdentityNumber(identityNumber);

            if (drugExist != null)
            {
                return await AddAsync(drug);
            }

            drug.IdentificationNumber = identityNumber;
            return await base.AddAsync(drug);
        }

        public async Task<Drug> GetDrugByIdentityNumber(string identityNumber)
        {
            return await _dbSet.Where(drug => drug.IdentificationNumber == identityNumber && drug.Status == 1).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Drug>> SearchForDrugByNameOrDescription(string name, string description, int page, int size)
        {
            var drugs = _dbSet.Where(drg => drg.Status == 1).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name.Trim()))
            {
                drugs = drugs.Where(drg => drg.Name.ToLower().Contains(name.ToLower()));
            }

            if (!string.IsNullOrEmpty(description.Trim()))
            {
                drugs = drugs.Where(drg => drg.Description.ToLower().Contains(description.ToLower()));
            }

            return await drugs.OrderBy(drg => drg.Name).Skip((page - 1) * size).Take(size).ToListAsync();
        }
    }
}
