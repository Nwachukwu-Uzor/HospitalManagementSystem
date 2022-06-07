namespace HospitalManagement.Domain.Models
{
    public class Patient : AppUser
    {
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
    }
}
