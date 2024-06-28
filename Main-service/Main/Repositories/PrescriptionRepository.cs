using Main.DTOs;
using Main.Interfaces;
using Main.Models;

namespace Main.Repositories;

public class PrescriptionRepository : ICrudRepository<Prescription>
{
    private MainDataContext _DataContext;

    public PrescriptionRepository(MainDataContext context)
    {
        _DataContext = context;
    }
    public void Create(Prescription variable)
    {
        throw new NotImplementedException();
    }

    public Prescription Delete(object identifier)
    {
        throw new NotImplementedException();
    }

    public List<Prescription> GetAll()
    {
        throw new NotImplementedException();
    }

    public Prescription GetSingle(object identifier)
    {
        throw new NotImplementedException();
    }

    public Prescription Update(Prescription update)
    {
        throw new NotImplementedException();
    }

    public List<PrescriptionDTO> GetAllPerscirptionsForUser(int userId)
    {
        var resultList = new List<PrescriptionDTO>();
        var list = _DataContext.Prescription.Where(x => x.PatientId == userId).ToList();
        foreach (var item in list)
        {
            PrescriptionDTO dto = new PrescriptionDTO(item.DateOfIssue,item.DoctorId,item.PatientId,item.Body);
            resultList.Add(dto);
        }
        return resultList;
    }
}