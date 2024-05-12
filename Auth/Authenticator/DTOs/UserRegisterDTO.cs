using Authenticator.Models;

namespace Authenticator.DTOs;

public class UserRegisterDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Roles Role {  get; set; }
}