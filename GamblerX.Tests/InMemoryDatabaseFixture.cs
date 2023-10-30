using GamblerX.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;


namespace GamblerX.Tests
{
    //Create a test fixture class for setting up and configuring the in-memory database
    public class InMemoryDatabaseFixture : IDisposable
    {
        public MyDbContext DbContext { get; }

        public InMemoryDatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            DbContext = new MyDbContext(options);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}


