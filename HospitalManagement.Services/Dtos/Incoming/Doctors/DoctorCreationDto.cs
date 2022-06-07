using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Services.Dtos.Incoming.Doctors
{
    public class DoctorCreationDto
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
    }
}
