using Authenticator.Interfaces;
using Authenticator.Models;
using System.Linq;

namespace Authenticator.Repository
{
    public class UserRepository : ICrudRepository<User>
    {
        private readonly UserDataContext _userDataContext;
        public UserRepository(UserDataContext userDataContext)
        {
            _userDataContext = userDataContext;
        }
        public void Create(User variable)
        {
            _userDataContext.Add(variable);
            _userDataContext.SaveChanges();
        }

        public void Delete(object identifier)
        {
            try
            {
                var userToDelete = _userDataContext?.Users.Find(identifier);
                _userDataContext.Remove<User>(userToDelete);
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

        public List<User> GetAll()
        {
            return _userDataContext.Users.ToList();
        }

        public User GetSingle(object identifier)
        {
            return _userDataContext.Users.Find(identifier);
        }

        public User Update(User update)
        {
            var userToUpdate = _userDataContext.Users.Find(update.Id);
            userToUpdate.Name = update.Name;
            userToUpdate.LastName = update.LastName;
            _userDataContext.Users.Update(userToUpdate);
            _userDataContext.SaveChanges();
            return userToUpdate;
        }

    }
}
