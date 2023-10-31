using System;
using System.Linq;
using GamblerX.Infrastructure;
using GamblerX.Infrastructure.Persistence;
using GamblerX.Domain.Entities;




namespace GamblerX.Tests.Infrastructure
{
    public class UserRepositoryTests : IClassFixture<InMemoryDatabaseFixture>
    {
        private readonly InMemoryDatabaseFixture _fixture;
        private readonly UserRepository _userRepository;
        private readonly MyDbContext _dbContext;

        public UserRepositoryTests()
        {
            _fixture = new InMemoryDatabaseFixture();
            _dbContext = _fixture.DbContext;
            _userRepository = new UserRepository(_dbContext);
        }

            [Fact]
            public void Add_Should_AddUserToDatabase()
            {
                // Arrange
                var user = new User { UserName = "Test_User", Email = "testUser@gmail.com", Password = "somestrongpassword" };

                // Act
                _userRepository.Add(user);
                var result = _dbContext.Users.SingleOrDefault();

                // Assert
                //assertions to verify user properties
                Assert.NotNull(result);
                Assert.Equal("Test_User", result.UserName);
                Assert.Equal("testUser@gmail.com", result.Email);
            }

            [Fact]
            public void GetUserByEmail_Should_ReturnUser()
            {
                // Arrange
                var userEmail = "test@example.com";
                var user = new User {  UserName = "Test_User", Email = userEmail };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                // Act
                var result = _userRepository.GetUserByEmail(userEmail);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Test_User", result.UserName);  // test username
                Assert.Equal(userEmail, result.Email);  // test email
            }

            [Fact]
            public void GetUserByEmail_Should_ReturnNullIfUserNotFound()
            {
                // Act
                var result = _userRepository.GetUserByEmail("nonexistent@example.com");

                // Assert
                Assert.Null(result);
            }
    }

}

