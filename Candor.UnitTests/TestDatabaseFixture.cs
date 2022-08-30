using Candor.DataAccess;
using Candor.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Candor.UnitTests;
public class TestDatabaseFixture
{
    private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=CandorTesting;Trusted_Connection=True";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    context.AddRange(
                        new Post { Title = "Post1", Content = "Content1"},
                        new Post { Title = "Post2", Content = "Content2"});
                    context.SaveChanges();
                }

                _databaseInitialized = true;
            }
        }
    }

    public ApplicationContext CreateContext()
        => new ApplicationContext(
            new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(ConnectionString)
                .Options);
}