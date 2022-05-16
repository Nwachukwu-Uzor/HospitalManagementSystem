using System.Collections.Generic;

namespace HospitalManagement.Data.Entities
{
    public class Doctor : BaseUser
    {
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
