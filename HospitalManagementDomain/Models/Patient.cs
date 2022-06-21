using HospitalManagementDomain.Enums;

namespace HospitalManagementDomain.Models
{
    public class Patient : AppUser
    {
        public BloodGroup BloodGroup { get; set; }
        public Genotype Genotype { get; set; }
    }
}
