using Authenticator.DTOs;
using Authenticator.Models;

namespace Authenticator.Service;

public class UserService
{
    private UserDataContext _dataContext;
    private TokenService _tokenService;
    public GetUserDTO getUserByEmail(string userEmail)
    {
        var user = FindUserObjectByEmail(userEmail);
        var userDto = user.MapToGetDTO();
        return userDto;
    }

    public User FindUserObjectByEmail(string userEmail)
    {
        var user = _dataContext.Users.Where(s=>s.Email == userEmail).First();
        return user;
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
       _dataContext.Users.Add(userObject);
       _dataContext.SaveChanges();
    }
}