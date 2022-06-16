using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Services.Dtos.Incoming.Patients
{
    public class PatientCreationDto : BaseUserCreation
    {
        [Required]
        [Range(0, 7, ErrorMessage = "Please provide a valid blood group")]
        public int BloodGroup { get; set; }

        [Range(0, 3, ErrorMessage = "Please provide a valid genotype")]
        public int Genotype { get; set; }
    }
}
