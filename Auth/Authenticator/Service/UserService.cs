using Authenticator.DTOs;
using Authenticator.Models;

namespace Authenticator.Service;

public class UserService
{
    private UserDataContext _dataContext;
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
}