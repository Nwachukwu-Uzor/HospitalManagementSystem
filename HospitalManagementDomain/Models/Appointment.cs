using System;

namespace HospitalManagementDomain.Models
{
    public class Appointment : BaseEntity
    {
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
