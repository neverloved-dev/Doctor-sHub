using Authenticator.DTOs;
using Authenticator.Models;
using Authenticator.Service;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers;

public class AuthenthicationController : Controller
{
    private IConfiguration _configuration ;
    private TokenService _tokenService;
    public AuthenthicationController(IConfiguration configuration,TokenService tokenService)
    {
        this._configuration = configuration;
        this._tokenService = tokenService;
    }
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
    public async Task<ActionResult<User>> LogIn(UserLoginDTO request)
    {
        if (user.Name != request.Name)
        {
            return BadRequest("User not found!");
        }
        if (!_tokenService.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return BadRequest("Wrong password!");
        }
        var token = _tokenService.CreateToken(user);
        return Ok(token);
    }
}