using GamblerX.Application.Services.Authentication;
using GamblerX.Application.Common.Interfaces.Authentication;
using GamblerX.Application.Common.Interfaces.Persistence;
using GamblerX.Domain.Entities;



namespace GamblerX.Tests.Application
{
    public class AuthenticationServiceTests
    {
        [Fact]
        public void Register_Should_RegisterUser()
        {
            // Arrange
            var jwTokenGenerator = new Mock<IJwTokenGenerator>();
            var userRepository = new Mock<IUserRepository>();
            
            var service = new AuthenticationService(jwTokenGenerator.Object, userRepository.Object);
            
            var userName = "TestUser";
            var email = "test@example.com";
            var password = "password123";
          
            User? user = null;
            userRepository.Setup(repo => repo.GetUserByEmail(email)).Returns(user);
            userRepository.Setup(repo => repo.GetUserByUserName(userName)).Returns(user);
            
            // Act
            var result = service.Register(userName, email, password);
            
            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.User);
            Assert.Equal(userName, result.User.UserName);
            Assert.Equal(email, result.User.Email);
        }
        
        [Fact]
        public void Login_Should_LoginUser()
        {
            // Arrange
            var jwTokenGenerator = new Mock<IJwTokenGenerator>();
            var userRepository = new Mock<IUserRepository>();
            
            var service = new AuthenticationService(jwTokenGenerator.Object, userRepository.Object);
            
            var email = "test@example.com";
            var password = "password123";
            var user = new User { Email = email, Password = password };
            
            userRepository.Setup(repo => repo.GetUserByEmail(email)).Returns(user);
            
            // Act
            var result = service.Login(email, password);
            
            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.User);
            Assert.Equal(email, result.User.Email);
        }
    }

}

