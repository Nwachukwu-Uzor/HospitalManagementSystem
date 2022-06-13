using HospitalManagement.Domain.Models;

namespace HospitalManagement.Domain.Contracts
{
    public interface IStaffRepository<T> : IUserRepository<T> where T : Staff
    {
    }
}
