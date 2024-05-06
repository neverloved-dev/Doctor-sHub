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
    public UserServiceTests() 
    {
        
        var db = GetInMemoryContext();
        UserRepository userRepository = new UserRepository(db);
        TokenService tokenService = new TokenService(configuration);
        UserService userService = new UserService(userRepository,tokenService);
        

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
        // Arrange
        var options = new DbContextOptionsBuilder<UserDataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new UserDataContext(options))
        {
            // Seed test data
            context.Users.Add(new User { Email = "test@example.com" /* Add more properties as needed */ });
            context.SaveChanges();

            var userRepository = new UserRepository(context);
            var tokenService = tokenService;

            var userService = new UserService(userRepository, tokenService);

            // Act
            var result = userService.FindUserObjectByEmail("test@example.com");

            // Assert
            Assert.NotNull(result);
            // Add assertions to verify the correctness of returned user
        }
    }

    [Fact]
    public void AddUser_Creates_New_User()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UserDataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new UserDataContext(options))
        {
            var userRepository = new UserRepository(context);
            var tokenService = _tokenService;

            var userService = new UserService(userRepository, tokenService);

            var userDto = new UserRegisterDTO { /* Populate user registration DTO */ };

            // Act
            userService.AddUser(userDto);

            // Assert
            Assert.Single(context.Users); // Ensure only one user is added
            // Add more assertions as needed to verify the correctness of added user
        }
    }

    [Fact]
    public void AddUser_CreatesNewUser()
    {

    }

    [Fact]
    public void GetAllUsers_ReturnsAllUsers()
    {

    }

    [Fact]
    public void DeleteUser_Deletes_User()
    {

    }

}