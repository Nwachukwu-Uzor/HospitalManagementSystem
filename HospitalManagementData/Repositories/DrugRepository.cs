using HospitalManagementBL.Contracts;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementData.Repositories
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

            drug.IdentificationNumber = identityNumber;
            return await base.AddAsync(drug);
        }

        public async Task<Drug> GetDrugByIdentityNumber(string identityNumber)
        {
            return await _dbSet.Where(drug => drug.IdentificationNumber == identityNumber).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Drug>> SearchForDrugByNameOrDescription(string name, string description, int page, int size)
        {
            var drugs = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                drugs = drugs.Where(drg => drg.Name.ToLower().Contains(name.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(description))
            {
                drugs = drugs.Where(drg => drg.Description.ToLower().Contains(description.Trim().ToLower()));
            }

            return await drugs.OrderBy(drg => drg.Name).Skip((page - 1) * size).Take(size).ToListAsync();
        }
    }
}
