using Microsoft.AspNetCore.Identity;

namespace Candor.Domain.Models;

/// <summary>
/// User.
/// </summary>
public class User : IdentityUser
{
    /// <summary>
    /// All posts made by the user.
    /// </summary>
    public IEnumerable<Post> Posts { get; init; }
}
