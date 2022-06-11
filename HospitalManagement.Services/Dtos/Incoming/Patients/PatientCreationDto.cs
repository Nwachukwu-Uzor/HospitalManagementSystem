using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Services.Dtos.Incoming.Patients
{
    public class PatientCreationDto
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        [MinLength(4)]
        public string LastName { get; set; }

        [Required]
        [MinLength(7)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(4)]
        public string Sex { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 2)]
        [RegularExpression(@"^(A|B|AB|O|a|b|ab|o)[+-]?$", ErrorMessage = "Blood group must be A+, AB+, AB-, A-, B+, B-, O+ or O-")]
        public string BloodGroup { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [RegularExpression(@"(AA|aa|AS|as|AC|ac|SS|as)", ErrorMessage = "Genotype must be either AA, AS, AC or SS")]
        public string Genotype { get; set; }


    }
}
