namespace Main.DTOs;

public class GetPrescriptionDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int PatientId { get; set; }
}