using HospitalManagementDomain.Models;

namespace HospitalManagementDomain.Contracts
{
    public interface IUnitOfWork
    {
        public IDoctorsRepository Doctors { get; }
        public IPatientsRepository Patients { get; }

        public IAppointmentsRepository Appointments { get; }

        public IDrugRepository Drugs { get; }
        public IDepartmentsRepository Departments { get; }
        public IStaffRepository<Staff> Staff { get; }
        public IDrugOrderRepository DrugOrders { get; }
        public IRefreshTokensRepository RefreshTokens { get; }
    }
}
