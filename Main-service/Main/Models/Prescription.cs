using Main.DTOs;

namespace Main.Models;

public class Prescription
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int PatientId { get; set; }
    
}