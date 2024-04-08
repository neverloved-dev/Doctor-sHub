namespace AuthenticatorTests
{
    public class AuthenticatorLoginTests
    {
         private Mock<IUserRepository> _mockUserRepository;
         private AuthenticationService _authService;

         public AuthenticatorLoginTests()
         {
            _mockUserRepository = new Mock<IUserRepository>();
            _authService = new AuthenticationService( _mockUserRepository.Object);
        }

    [Fact]
    public async Task Login_InvalidUser_ThrowsUnauthorizedAccessException()
    {
        _mockUserRepository.Setup(x => x.GetUserByUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(null));
        await Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _authService.Login("invalid", "password"));
    }

    [Fact]
    public async Task Login_ValidCredentials_ReturnsToken()
    {
        var user = new User { Id = 1, Username = "testuser", PasswordHash = "hashedPassword" };
        _mockUserRepository.Setup(x => x.GetUserByUsername(It.IsAny<string>())).Returns(Task.FromResult(user));
        _authService.VerifyPassword = (password, hash) => hash == user.PasswordHash;

    }
}
}