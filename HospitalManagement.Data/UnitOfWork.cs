using HospitalManagement.Data.Contracts;

namespace HospitalManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorsRepository Doctors { get; }

        public IPatientsRepository Patients { get; }

        public IAppointmentsRepository Appointments { get; }

        public UnitOfWork(IDoctorsRepository doctors, IPatientsRepository patients, IAppointmentsRepository appointments)
        {
            Doctors = doctors;
            Patients = patients;
            Appointments = appointments;
        }
    }
}
