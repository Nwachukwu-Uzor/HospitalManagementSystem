using HospitalManagement.Domain.Enums;

namespace HospitalManagement.Domain.Models
{
    public class Patient : AppUser
    {
        public BloodGroup BloodGroup { get; set; }
        public Genotype Genotype { get; set; }
    }
}
