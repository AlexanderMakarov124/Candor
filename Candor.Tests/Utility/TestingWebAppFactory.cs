using Candor.DataAccess;
using Candor.UseCases.Authorization.Register;
using Candor.Web;
using Candor.Web.MappingProfiles;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Candor.IntegrationTests.Utility
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<ApplicationContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseInMemoryDatabase("CandorInMemoryDatabase").UseLazyLoadingProxies();
                });

                services.AddMediatR(typeof(RegisterCommand).Assembly);

                services.AddAutoMapper(typeof(UserMappingProfile).Assembly);

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();

                var serviceProvider = scope.ServiceProvider;

                using var db = serviceProvider.GetRequiredService<ApplicationContext>();

                var logger = serviceProvider.GetRequiredService<ILogger<TestingWebAppFactory<TEntryPoint>>>();

                try
                {
                    db.Database.EnsureCreated();
                    Utilities.InitializeDbForTests(db);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the database with test messages. Error: {Message}", ex.Message);
                }
            });
        }
    }
}
