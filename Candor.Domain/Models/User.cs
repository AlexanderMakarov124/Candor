using Microsoft.AspNetCore.Identity;

namespace Candor.Domain.Models;

/// <summary>
/// User.
/// </summary>
public class User : IdentityUser
{
    /// <summary>
    /// All posts made by a user.
    /// </summary>
    public virtual IEnumerable<Post> Posts { get; init; }
}
