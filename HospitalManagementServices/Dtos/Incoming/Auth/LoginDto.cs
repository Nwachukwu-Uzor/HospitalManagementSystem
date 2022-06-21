using System.ComponentModel.DataAnnotations;

namespace HospitalManagementServices.Dtos.Incoming.Auth
{
    public class LoginDto
    {
        [Required]
        [MinLength(7)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
