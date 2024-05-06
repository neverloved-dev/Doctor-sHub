using Authenticator.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Authenticator.Models;

public class User
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Roles Role { get; set; }

    public GetUserDTO MapToGetDTO()
    {
        GetUserDTO getUserDto = new GetUserDTO();
        getUserDto.Name = this.Name;
        getUserDto.LastName = this.LastName;
        getUserDto.Email = this.Email;
        getUserDto.PhoneNumber = this.PhoneNumber;
        getUserDto.DateOfBirth = this.DateOfBirth;
        return getUserDto;
    }
    
}