using System.ComponentModel.DataAnnotations;

namespace Authenticator.DTOs
{
    public class DoctorLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
