using System.ComponentModel.DataAnnotations;

namespace Main.DTOs
{
    public class PrescriptionDTO
    {
        [Required] public DateTime DateOfIssue { get; set; }
        [Required] public int DoctorId { get; set; }
        [Required] public int PatientId { get; set; }
        [Required] public string Body { get; set; }

        public PrescriptionDTO(DateTime dateTime,int DoctorId,int PatientId,string Body) 
        {
            this.DoctorId = DoctorId;
            this.PatientId = PatientId;
            this.Body = Body;
            this.DateOfIssue = dateTime;
        }
    }
}
