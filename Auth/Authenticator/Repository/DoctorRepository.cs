using Authenticator.Interfaces;
using Authenticator.Models;
using System.Linq;

namespace Authenticator.Repository
{
    public class DoctorRepository : ICrudRepository<Doctor>
    {
        private readonly UserDataContext _userDataContext;
        public DoctorRepository(UserDataContext userDataContext)
        {
            _userDataContext = userDataContext;
        }
        public void Create(Doctor variable)
        {
            _userDataContext.Add(variable);
            _userDataContext.SaveChanges();
        }

        public void Delete(object identifier)
        {
            try
            {
                var doctorToDelete = _userDataContext?.Doctors.Find(identifier);
                _userDataContext.Remove<Doctor>(doctorToDelete);
                _userDataContext.SaveChanges();
            }
            catch(NullReferenceException exception)
            {
                throw exception;
            }
            finally
            {
                GetAll();
            }
            
        }

        public List<Doctor> GetAll()
        {
            return _userDataContext.Doctors.ToList();
        }

        public Doctor GetSingle(object identifier)
        {
            return _userDataContext.Doctors.Find(identifier);
        }

        public Doctor Update(Doctor update)
        {
            var doctorToUpdate = _userDataContext.Doctors.Find(update.Id);
            doctorToUpdate.Name = update.Name;
            doctorToUpdate.LastName = update.LastName;
            doctorToUpdate.Specialization = update.Specialization;
            doctorToUpdate.YearsOfExperience = update.YearsOfExperience;
            _userDataContext.Doctors.Update(doctorToUpdate);
            _userDataContext.SaveChanges();
            return doctorToUpdate;
        }
    }
}
