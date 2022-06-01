using HospitalManagement.Data.Entities;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Contracts
{
    public interface IDrugRepository : IGenericRepository<Drug>
    {
        Task<Drug> GetDrugByIdentityNumber(string identityNumber);
    }
}
