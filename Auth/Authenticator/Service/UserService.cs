using Authenticator.DTOs;
using Authenticator.Models;
using Authenticator.Repository;

namespace Authenticator.Service;

public class UserService
{
    private UserRepository _userRepository;
    private TokenService _tokenService;

    public UserService(UserRepository userRepository, TokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

  
    public User FindUserObjectByEmail(string userEmail)
    {
        return _userRepository.FindUserByEmail(userEmail);
    }

    public void AddUser(UserRegisterDTO user)
    {
        User userObject = new User();
        userObject.Email = user.Email;
        userObject.Name = user.Name;
        userObject.PhoneNumber = user.PhoneNumber;
        userObject.LastName = user.LastName;
        userObject.DateOfBirth = user.DateOfBirth;
       _tokenService.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
       userObject.PasswordHash = passwordHash;
       userObject.PasswordSalt = passwordSalt;
        _userRepository.Create(userObject);
    }

    public void DeleteUser(int id)
    {
        _userRepository.Delete(id);
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public User EditUser(User user)
    {
        return _userRepository.Update(user);
    }
}