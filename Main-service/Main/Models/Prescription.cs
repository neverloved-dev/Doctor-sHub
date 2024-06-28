using System.ComponentModel.DataAnnotations;

namespace Main.Models;

public class Prescription
{
    [Required]
    public int Id { get; set; }
    [Required] public DateTime DateOfIssue { get; set; }
    [Required] public int DoctorId { get; set; }
    [Required] public int PatientId { get; set; }
    [Required] public string Body {  get; set; }
}