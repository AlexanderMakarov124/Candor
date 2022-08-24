using Candor.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Candor.DataAccess;

/// <summary>
/// Data base application context.
/// </summary>
public class ApplicationContext : IdentityDbContext<User>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    /// <summary>
    /// Posts DB set.
    /// </summary>
    public DbSet<Post> Posts { get; protected set; }
}
