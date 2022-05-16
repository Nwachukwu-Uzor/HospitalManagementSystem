using System.Collections.Generic;

namespace HospitalManagement.Data.Entities
{
    public class Patient : BaseUser
    {
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
