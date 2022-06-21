using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementDomain.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllPaginatedAsync(int pageNumber, int pageSize, List<string> options = null);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
