using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticatorTests
{
    public class AuthenticatorSignUpTests
    {

         private Mock<IUserRepository> _mockUserRepository;
         private AuthenticationService _authService;

         public AuthenticatorSignUpTests()
         {
            _mockUserRepository = new Mock<IUserRepository>();
            _authService = new AuthenticationService( _mockUserRepository.Object);
        }
    [Fact]
    public async Task Register_ValidUser_ReturnsToken()
    {
        var user = new User { Username = "testuser", Password = "password" };
        _mockUserRepository.Setup(x => x.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
        var token = await _authService.Register(user);
        Assert.NotNull(token);
    }
    [Fact] //Use theory instead
    public async Task Register_InvalidBody_ThrowsErrorMessge()
    {

    }

    }
}