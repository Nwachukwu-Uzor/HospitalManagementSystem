using HospitalManagement.Data.Contracts;

namespace HospitalManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorsRepository Doctors { get; }

        public IPatientsRepository Patients { get; }

        public UnitOfWork(IDoctorsRepository doctors, IPatientsRepository patients)
        {
            Doctors = doctors;
            Patients = patients;
        }
    }
}
