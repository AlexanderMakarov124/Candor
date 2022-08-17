using Microsoft.AspNetCore.Identity;

namespace Candor.Domain.Models;

/// <summary>
/// User.
/// </summary>
public class User : IdentityUser
{
    /// <summary>
    /// Real name.
    /// </summary>
    public string? Name { get; set; }
}
