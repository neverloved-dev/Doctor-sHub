using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Authenticator.DTOs
{
    public class DoctorRegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int YearsOfExperience { get; set; }
        [Required]
        public string Specialization {  get; set; }

    }
}
