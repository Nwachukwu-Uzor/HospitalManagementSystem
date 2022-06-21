using HospitalManagementDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementDomain.Contracts
{
    public interface IDrugRepository : IGenericRepository<Drug>
    {
        Task<Drug> GetDrugByIdentityNumber(string identityNumber);
        Task<IEnumerable<Drug>> SearchForDrugByNameOrDescription(string name, string description, int page, int size);
    }
}
