using GamblerX.API.Controllers;
using GamblerX.Application.Services.Authentication;
using GamblerX.Contracts.Authentication;
using GamblerX.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GamblerX.Tests.Controllers;

public class AuthenticationControllerTests
{
        private AuthenticationController _authenticationController;
        private Mock<IAuthenticationService> _authenticationServiceMock;

        public AuthenticationControllerTests()
        {
            _authenticationServiceMock = new Mock<IAuthenticationService>();
            _authenticationController = new AuthenticationController(_authenticationServiceMock.Object);
        }

        [Fact]
        public void Register_ValidRegistration_ReturnsOkWithToken()
        {
            // Arrange
            var registerRequest = new RegisterRequest
            {
                FirstName = "Olu",
                LastName = "Bunmi",
                Email = "olubunmi@gmail.com",
                Password = "password"
            };

            var expectedAuthResult = new AuthenticationResult
            {
                User = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Olu",
                    LastName = "Bunmi",
                    Email = "olubunmi@gmail.com"
                },
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzY2NkOWE4NC1kZTlkLTRhZjItYmVhYS1hMGM0NzU0N2M4OWIiLCJnaXZlbl9uYW1lIjoiT2x1IiwiZmFtaWx5X25hbWUiOiJCdW5taSIsImp0aSI6IjJkYjIwNGNmLWFjYjktNDc3Zi1hMDI3LTczZTQwMmUwMjZkZiIsImV4cCI6MTY5NjM4MTg4MywiaXNzIjoiR2FtYmxlclgiLCJhdWQiOiJHYW1ibGVyWCJ9.m5epstJnR3nPJuhRnW0Ny7c-VNygz-Y-_9nRf1Sje_I"
            };



            _authenticationServiceMock.Setup(x => x.Register(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password))
                .Returns(expectedAuthResult);



            // Act
            var result = _authenticationController.Register(registerRequest);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);

            var response = Assert.IsType<AuthenticationResponse>(okResult.Value);
            Assert.Equal(expectedAuthResult.User.FirstName, response.FirstName);
            Assert.Equal(expectedAuthResult.User.LastName, response.LastName);
            Assert.Equal(expectedAuthResult.User.Email, response.Email);
            Assert.Equal(expectedAuthResult.Token, response.Token);

        }

        [Fact]
        public void Login_ValidLogin_ReturnsOkWithToken()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                Email = "olubunmi@gmail.com",
                Password = "password"
            };

            var expectedAuthResult = new AuthenticationResult
            {
                User = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Olu",
                    LastName = "Bunmi",
                    Email = "olubunmi@gmail.com"
                },
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzY2NkOWE4NC1kZTlkLTRhZjItYmVhYS1hMGM0NzU0N2M4OWIiLCJnaXZlbl9uYW1lIjoiT2x1IiwiZmFtaWx5X25hbWUiOiJCdW5taSIsImp0aSI6IjJkYjIwNGNmLWFjYjktNDc3Zi1hMDI3LTczZTQwMmUwMjZkZiIsImV4cCI6MTY5NjM4MTg4MywiaXNzIjoiR2FtYmxlclgiLCJhdWQiOiJHYW1ibGVyWCJ9.m5epstJnR3nPJuhRnW0Ny7c-VNygz-Y-_9nRf1Sje_I"
            };

            _authenticationServiceMock.Setup(x => x.Login(loginRequest.Email, loginRequest.Password))
                .Returns(expectedAuthResult);

            // Act
            var result = _authenticationController.Login(loginRequest);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);

            var response = Assert.IsType<AuthenticationResponse>(okResult.Value);
            Assert.Equal(expectedAuthResult.User.FirstName, response.FirstName);
            Assert.Equal(expectedAuthResult.User.LastName, response.LastName);
            Assert.Equal(expectedAuthResult.User.Email, response.Email);
            Assert.Equal(expectedAuthResult.Token, response.Token);
        }
}