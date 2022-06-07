using HospitalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Contracts
{
    public interface IAppointmentsRepository : IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(string patientIdentityNumber, int pageSize, int page);
        Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(string doctorIdentityNumber, int pageSize, int page);
        Task<IEnumerable<Appointment>> GetDailyAppointmentsForDoctorAsync(string doctorIdentityNumber, DateTime date);
        Task<IEnumerable<Appointment>> GetAppointmentsForTheNextDay();
    }
}
