using HospitalManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Contracts
{
    public interface IStaffRepository<T> : IUserRepository<T> where T : Staff
    {
        Task<IEnumerable<Staff>> GetStaffForDepartment(string departmentNumber, int page, int size);
    }
}
