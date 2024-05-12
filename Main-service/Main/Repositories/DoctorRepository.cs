using Main.Interfaces;
using Main.Models;

namespace Main.Repositories;

public class DoctorRepository : ICrudRepository<Doctor> //TODO: Implement CRUD repository and then use them in the Service.
{
    public void Create(Doctor variable)
    {
        throw new NotImplementedException();
    }

    public Doctor Delete(object identifier)
    {
        throw new NotImplementedException();
    }

    public List<Doctor> GetAll()
    {
        throw new NotImplementedException();
    }

    public Doctor GetSingle(object identifier)
    {
        throw new NotImplementedException();
    }

    public Doctor Update(Doctor update)
    {
        throw new NotImplementedException();
    }
}