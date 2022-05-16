using HospitalManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Contracts
{
    public interface IDoctorsRepository : IGenericRepository<Doctor>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(Guid doctorId, int pageSize, int page);
        Task<IEnumerable<Appointment>> GetDailyAppointmentsForDoctorAsync(Guid doctorId, DateTime date);
        Task<Doctor> GetDoctorByIdentityNumber(string identityNumber);
    }
}
