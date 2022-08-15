using Microsoft.AspNetCore.Identity;

namespace Candor.Domain.Models;
public class User : IdentityUser
{
    public string? Name { get; set; }
}
