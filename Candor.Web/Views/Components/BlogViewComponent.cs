using Candor.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Web.Views.Components;

/// <summary>
/// Blog view component.
/// </summary>
public class BlogViewComponent : ViewComponent
{
    /// <summary>
    /// Invokes component.
    /// </summary>
    /// <param name="posts">Blog posts.</param>
    /// <returns>View with posts.</returns>
    public IViewComponentResult Invoke(IEnumerable<Post> posts)
    {
        return View("Blog", posts);
    }
}
