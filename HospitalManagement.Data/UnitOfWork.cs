using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;

namespace HospitalManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorsRepository Doctors { get; }

        public IPatientsRepository Patients { get; }

        public IAppointmentsRepository Appointments { get; }

        public IDrugRepository Drugs { get; }

        public IDepartmentsRepository Departments { get; }

        public IStaffRepository<Staff> Staff { get; }

        public IDrugOrderRepository DrugOrders { get; }

        public IRefreshTokensRepository RefreshTokens { get; }

        public UnitOfWork(
            IDoctorsRepository doctors, IPatientsRepository patients, 
            IAppointmentsRepository appointments, IDrugRepository drugs,
            IDepartmentsRepository departments, IStaffRepository<Staff> staff,
            IDrugOrderRepository drugOrders, IRefreshTokensRepository refreshTokens
        )
        {
            Doctors = doctors;
            Patients = patients;
            Appointments = appointments;
            Drugs = drugs;
            Departments = departments;
            Staff = staff;
            DrugOrders = drugOrders;
            RefreshTokens = refreshTokens;
        }
    }
}
