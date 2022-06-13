using HospitalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Contracts
{
    public interface IUnitOfWork
    {
        public IDoctorsRepository Doctors { get; }
        public IPatientsRepository Patients { get; }

        public IAppointmentsRepository Appointments { get; }

        public IDrugRepository Drugs { get; }
        public IDepartmentsRepository Departments { get; }
        public IStaffRepository<Staff> Staff { get; }
    }
}
