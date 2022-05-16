using HospitalManagement.Data.Contracts;

namespace HospitalManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorsRepository Doctors { get; }

        public UnitOfWork(IDoctorsRepository doctors)
        {
            Doctors = doctors;
        }
    }
}
