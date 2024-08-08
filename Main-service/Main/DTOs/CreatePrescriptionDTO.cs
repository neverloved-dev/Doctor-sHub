using Main.Models;

namespace Main.DTOs;

public class CreatePrescriptionDTO
{
    public string Title { get; set; }
    public int PatientId { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    
}