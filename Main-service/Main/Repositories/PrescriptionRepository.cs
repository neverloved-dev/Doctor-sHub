using Main.Models;

namespace Main.Repositories;

public class PrescriptionRepository
{
    private MainContext _appContext;

    public PrescriptionRepository(MainContext appContext)
    {
        _appContext = appContext;
    }

    public void AddPrescription(Prescription createPrescriptionDTO)
    {
        _appContext.Prescriptions.Add(createPrescriptionDTO);
        _appContext.SaveChanges();
    }

    public Prescription GetPrescription(int prescriptionId) => _appContext.Prescriptions.Find(prescriptionId);

    public List<Prescription> GetPrescriptionList(int patientId)
    {
        List<Prescription> result = _appContext.Prescriptions.Where(x=>x.PatientId == patientId).ToList();
        return result;
    }



}