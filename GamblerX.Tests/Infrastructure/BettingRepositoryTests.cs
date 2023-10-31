using System.Runtime.InteropServices;
using System;
using System.Linq;
using GamblerX.Infrastructure;
using GamblerX.Infrastructure.Persistence;
using GamblerX.Domain.Entities;


namespace GamblerX.Tests.Infrastructure
{
    public class BettingRepositoryTests : IClassFixture<InMemoryDatabaseFixture>
    {
        private readonly InMemoryDatabaseFixture _fixture;
        private readonly BettingRepository _bettingRepository;
        private readonly MyDbContext _dbContext;

        public BettingRepositoryTests()
        {
            _fixture = new InMemoryDatabaseFixture();
            _dbContext = _fixture.DbContext;
            _bettingRepository = new BettingRepository(_dbContext);
        }


        [Fact]
        public async Task AddBettingAsync_Should_AddBetting()
        {
            // Arrange
            var repository = new BettingRepository(_dbContext);
            var betting = new Betting { Id = Guid.NewGuid(), EventName = "Chelsea Vs Arsenal", EventTime = DateTime.Now };

            // Act
            var addedBetting = await repository.AddBettingAsync(betting);

            // Assert
            Assert.NotNull(addedBetting);
            Assert.Equal(betting.Id, addedBetting.Id);
            Assert.Equal(betting.EventName, addedBetting.EventName);
        }

        [Fact]
        public async Task UpdateBettingAsync_Should_UpdateExistingBetting()
        {
            // Arrange
            var repository = new BettingRepository(_dbContext);
            var betting = new Betting { Id = Guid.NewGuid(), EventName = "Chelsea Vs Arsenal", EventTime = DateTime.Now };
         
            _dbContext.Bettings.Add(betting);
            _dbContext.SaveChanges();

            var updatedBetting = new Betting
            {
                Id = betting.Id,
                EventName = "Updated Event",
                EventTime = DateTime.Now.AddDays(1)
            };

            // Act
            var result = await repository.UpdateBettingAsync(betting.Id, updatedBetting);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(betting.Id, result.Id);
            Assert.Equal(updatedBetting.EventName, result.EventName);
            // Add more assertions to verify other properties.
        }

        [Fact]
        public async Task UpdateBettingAsync_Should_ReturnNullIfNotExists()
        {
            // Arrange
            var repository = new BettingRepository(_dbContext);
            var nonExistentId = Guid.NewGuid();
            var updatedBetting = new Betting { Id = nonExistentId, EventName = "Updated Event" };

            // Act
            var result = await repository.UpdateBettingAsync(nonExistentId, updatedBetting);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteBettingAsync_Should_DeleteBetting()
        {
            // Arrange
            var repository = new BettingRepository(_dbContext);
            var betting = new Betting { EventName = "Test Event", EventTime = DateTime.Now };
            _dbContext.Bettings.Add(betting);
            _dbContext.SaveChanges();

            // Act
            var result = await repository.DeleteBettingAsync(betting.Id);

            // Assert
            Assert.True(result);
            Assert.Null(_dbContext.Bettings.Find(betting.Id)); // Ensure it's deleted from the database.
        }

        [Fact]
        public async Task DeleteBettingAsync_Should_ReturnFalseIfNotExists()
        {
            // Arrange
            var repository = new BettingRepository(_dbContext);
            var nonExistentId = Guid.NewGuid();

            // Act
            var result = await repository.DeleteBettingAsync(nonExistentId);

            // Assert
            Assert.False(result);
        }
    }
}