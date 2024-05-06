using Authenticator.DTOs;
using Authenticator.Models;
using Authenticator.Service;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers;

public class AuthenthicationController : Controller
{
    private IConfiguration _configuration;
    private TokenService _tokenService;
    private UserService _userService;
    public AuthenthicationController(IConfiguration configuration, TokenService tokenService, UserService userService)
    {
        this._configuration = configuration;
        this._tokenService = tokenService;
        this._userService = userService;
    }

    [HttpPost("/admin/doctor/register")]
    [HttpDelete("/admin/doctor/delete/{doctorId}")]
    [HttpPost("/admin/assistant/register")]
    [HttpDelete("/admin/assistant/delete/{doctorId}")]


    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserRegisterDTO request)
    {
        User user = new User();
        _tokenService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
        user.Name = request.Name;
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;
        return Ok(user);

    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> LogIn(UserLoginDTO request,Roles role)
    {
        var userDto = _userService.FindUserObjectByEmail(request.Email);
        if (userDto == null)
        {
            return NotFound("User not found!");
        }

        var user = _userService.FindUserObjectByEmail(userDto.Email);
        if (!_tokenService.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return BadRequest("Wrong password!");
        }
        var token = _tokenService.CreateToken(user,role);
        return Ok(token);
    }

}