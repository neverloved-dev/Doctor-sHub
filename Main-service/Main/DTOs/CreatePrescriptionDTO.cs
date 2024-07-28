using Main.Models;

namespace Main.DTOs;

public class CreatePrescriptionDTO
{
    public Doctor doctor { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    
}