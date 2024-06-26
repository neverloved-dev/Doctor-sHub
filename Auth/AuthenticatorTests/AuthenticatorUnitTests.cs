using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authenticator.Models;
using Authenticator.Service;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AuthenticatorTests
{
    public class AuthenticatorUnitTests
    {
        [Fact]
        public void CreatePasswordHash_Returns_Valid_Hash_And_Salt()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            var tokenService = new TokenService(configuration.Object);
            byte[] passwordHash, passwordSalt;

            // Act
            tokenService.CreatePasswordHash("password", out passwordHash, out passwordSalt);

            // Assert
            Assert.NotNull(passwordHash);
            Assert.NotNull(passwordSalt);
            Assert.True(passwordHash.Length > 0);
            Assert.True(passwordSalt.Length > 0);
        }

        [Fact]
        public void VerifyPassword_Returns_True_When_Password_Is_Correct()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            var tokenService = new TokenService(configuration.Object);
            var password = "password";
            byte[] passwordHash, passwordSalt;
            tokenService.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // Act
            var result = tokenService.VerifyPassword(password, passwordHash, passwordSalt);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPassword_Returns_False_When_Password_Is_Incorrect()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            var tokenService = new TokenService(configuration.Object);
            var correctPassword = "correctPassword";
            var incorrectPassword = "incorrectPassword";
            byte[] passwordHash, passwordSalt;
            tokenService.CreatePasswordHash(correctPassword, out passwordHash, out passwordSalt);

            // Act
            var result = tokenService.VerifyPassword(incorrectPassword, passwordHash, passwordSalt);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CreateToken_Returns_Valid_Token()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetSection("AppSettings:Token").Value).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IngwbnIiLCJzdWIiOiJ4MG5yIiwianRpIjoiZmRkMmYzYTAiLCJhdWQiOlsiaHR0cDovL2xvY2FsaG9zdDo1ODk5MiIsImh0dHBzOi8vbG9jYWxob3N0OjAiLCJodHRwOi8vbG9jYWxob3N0OjUxMjIiXSwibmJmIjoxNzE1MDExNTkxLCJleHAiOjE3MjI5NjAzOTEsImlhdCI6MTcxNTAxMTU5MiwiaXNzIjoiZG90bmV0LXVzZXItand0cyJ9.QaI5vPGK6ei4fP-6IAjJwrjF1Os0Tgrqnt-buqcPyBk");
            var tokenService = new TokenService(configuration.Object);
            var user = new User { Name = "TestUser" };

            // Act
             var token = tokenService.CreateToken(user,Roles.Admin);

            // Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }
        
    }
}