namespace AuthenticatorTests;

using Authenticator.DTOs;
using Authenticator.Models;
using Authenticator.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserServiceTests
{
    [Fact]
    public void GetUserByEmail_Returns_UserDTO_When_UserExists()
    {
        // Arrange
        var userEmail = "test@example.com";
        var expectedUserDto = new GetUserDTO { /* Populate expected user DTO */ };

        var userService = new UserService(MockDataContextWithExistingUser(), MockTokenService());

        // Act
        var result = userService.FindUserObjectByEmail(userEmail);

        // Assert
        Assert.NotNull(result);
        // Add more assertions to verify the correctness of returned DTO
    }

    [Fact]
    public void GetUserByEmail_Returns_Null_When_UserDoesNotExist()
    {
        // Arrange
        var userEmail = "nonexistent@example.com";
        var userService = new UserService(MockDataContextWithoutUser(), MockTokenService());

        // Act
        var result = userService.FindUserObjectByEmail(userEmail);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AddUser_Creates_New_User()
    {
        // Arrange
        var userDto = new UserRegisterDTO { /* Populate user registration DTO */ };
        var userService = new UserService(MockDataContext(), MockTokenService());

        // Act
        userService.AddUser(userDto);

        // Assert
        // Verify user is added to data context by querying or any other means
    }

    // Helper methods to mock dependencies

    private UserDataContext MockDataContextWithExistingUser()
    {
        var mockDataContext = new Mock<UserDataContext>();
        mockDataContext.Setup(dc => dc.Users).Returns((Microsoft.EntityFrameworkCore.DbSet<User>)new[] { new User() }.AsQueryable());
        return mockDataContext.Object;
    }

    private UserDataContext MockDataContextWithoutUser()
    {
        var mockDataContext = new Mock<UserDataContext>();
        mockDataContext.Setup(dc => dc.Users).Returns((Microsoft.EntityFrameworkCore.DbSet<User>)Enumerable.Empty<User>().AsQueryable());
        return mockDataContext.Object;
    }

    private UserDataContext MockDataContext()
    {
        var mockDataContext = new Mock<UserDataContext>();
        mockDataContext.Setup(dc => dc.Users).Returns((Microsoft.EntityFrameworkCore.DbSet<User>)new List<User>().AsQueryable());
        return mockDataContext.Object;
    }

    private TokenService MockTokenService()
    {
        var mockTokenService = new Mock<TokenService>();
        return mockTokenService.Object;
    }
}