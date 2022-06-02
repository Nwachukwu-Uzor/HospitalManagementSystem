using HospitalManagement.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Contracts
{
    public interface IDrugRepository : IGenericRepository<Drug>
    {
        Task<Drug> GetDrugByIdentityNumber(string identityNumber);
        Task<IEnumerable<Drug>> SearchForDrugByNameOrDescription(string name, string description, int page, int size);
    }
}
