using Authenticator.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Authenticator.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int YearsOfExperience { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public GetDoctorDTO MapToGetDTO()
        {
            GetDoctorDTO dto = new GetDoctorDTO();
            dto.Specialization = Specialization;
            dto.LastName = LastName;
            dto.Name = Name;
            dto.YearsOfExperience = YearsOfExperience;
            return dto; 
        }

    }
}
