using HospitalManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Contracts
{
    public interface IDrugRepository : IGenericRepository<Drug>
    {
        Task<Drug> GetDrugByIdentityNumber(string identityNumber);
        Task<IEnumerable<Drug>> SearchForDrugByNameOrDescription(string name, string description, int page, int size);
    }
}
