using HospitalManagement.Data.Contracts;

namespace HospitalManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorsRepository Doctors { get; }

        public IPatientsRepository Patients { get; }

        public IAppointmentsRepository Appointments { get; }

        public IDrugRepository Drugs { get; }

        public UnitOfWork(
            IDoctorsRepository doctors, IPatientsRepository patients, 
            IAppointmentsRepository appointments, IDrugRepository drugs
        )
        {
            Doctors = doctors;
            Patients = patients;
            Appointments = appointments;
            Drugs = drugs;
        }
    }
}
