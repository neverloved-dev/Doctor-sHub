namespace AuthenticatorTests;

using Authenticator.DTOs;
using Authenticator.Models;
using Authenticator.Repository;
using Authenticator.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserServiceTests:IDisposable
{
    private IConfiguration configuration;
    private UserRepository userRepository;
    private TokenService tokenService;
    private UserService userService;
    public UserServiceTests() 
    {
        
        var db = GetInMemoryContext();
         userRepository = new UserRepository(db);
         tokenService = new TokenService(configuration);
         userService = new UserService(userRepository, tokenService);
        

    }

    public UserDataContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<UserDataContext>()
        .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
        .Options;
        return new UserDataContext(options);
    }
    public void Dispose()
    {
        using (var context = GetInMemoryContext())
        {
            context.Database.EnsureDeleted();
        }
    }


    [Fact]
    public void FindUserObjectByEmail_Returns_User_When_UserExists()
    {
        User user = new User();
        Random rnd = new Random();
        user.Id = rnd.Next(1, 99);
        user.DateOfBirth = DateTime.UtcNow;
        user.PhoneNumber = Guid.NewGuid().ToString();
        user.Role = Roles.Patient;
        user.Email = "testmail@mail.com";
        user.Name = "Test";
        user.LastName = "Last Test";
        byte[] passwordHash = { };
        byte[] passwordSalt = { };
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        userRepository.Create(user);
        var foundUser = userService.FindUserObjectByEmail(user.Email);
        Assert.NotNull(foundUser);
        Assert.Equal(user.Email, foundUser.Email);
        Assert.Equal(user.Name, foundUser.Name);
    }

    [Fact]
    public void AddUser_Creates_New_User()
    {
        UserRegisterDTO userRegisterDTO = new UserRegisterDTO();
        userRegisterDTO.Email = "test2mail.com";
        userRegisterDTO.Name = "Test";
        userRegisterDTO.LastName = "Last Test Name";
        userRegisterDTO.PhoneNumber = Guid.NewGuid().ToString(); 
        userRegisterDTO.DateOfBirth = DateTime.UtcNow;
        userRegisterDTO.Password = "MySuperStrongPassword";
        userRegisterDTO.Role = Roles.Doctor;
        userService.AddUser(userRegisterDTO);
        var foundUser = userRepository.FindUserByEmail(userRegisterDTO.Email);
        Assert.NotNull(foundUser);
        Assert.Equal(userRegisterDTO.Email, foundUser.Email);
        Assert.Equal(userRegisterDTO.DateOfBirth, foundUser.DateOfBirth);
        Assert.Equal(userRegisterDTO.PhoneNumber,foundUser.PhoneNumber);
    }


    [Fact]
    public void GetAllUsers_ReturnsAllUsers()
    {
        // Arrange
        var users = new List<User>
    {
        new User { Id = 1, Email = "user1@example.com", Name = "User1", LastName = "Last1", PasswordHash = new byte[1], PasswordSalt = new byte[1], PhoneNumber = "1234567890" },
        new User { Id = 2, Email = "user2@example.com", Name = "User2", LastName = "Last2", PasswordHash = new byte[1], PasswordSalt = new byte[1], PhoneNumber = "1234567891" },
        new User { Id = 3, Email = "user3@example.com", Name = "User3", LastName = "Last3", PasswordHash = new byte[1], PasswordSalt = new byte[1], PhoneNumber = "1234567892" }
    };
        foreach (var user in users)
        {
            userRepository.Create(user);
        }

        // Act
        var allUsers = userService.GetAllUsers();

        // Assert
        Assert.NotNull(allUsers);
        Assert.Equal(users.Count, allUsers.Count);

        foreach (var user in users)
        {
            Assert.Contains(allUsers, u => u.Id == user.Id && u.Email == user.Email && u.Name == user.Name && u.LastName == user.LastName && u.PasswordHash != null && u.PasswordSalt != null && u.PhoneNumber == user.PhoneNumber);
        }
    }

    [Fact]
    public void DeleteUser_Deletes_User()
    {
        // Arrange
        var user = new User { Id = 1, Email = "deleteuser@example.com", Name = "DeleteUser", LastName = "Last", PasswordHash = new byte[1], PasswordSalt = new byte[1], PhoneNumber = "1234567890" };
        userRepository.Create(user);

        // Act
        userService.DeleteUser(user.Id);

        // Assert
        var deletedUser = userRepository.GetSingle(user.Id);
        Assert.Null(deletedUser);
    }



}