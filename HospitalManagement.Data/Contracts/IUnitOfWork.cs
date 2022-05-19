using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Contracts
{
    public interface IUnitOfWork
    {
        public IDoctorsRepository Doctors { get; }
        public IPatientsRepository Patients { get; }

        public IAppointmentsRepository Appointments { get; }
    }
}
