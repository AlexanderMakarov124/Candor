using Candor.Domain.Models;
using Candor.Infrastructure.Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Web.Views.Components;

/// <summary>
/// Blog view component.
/// </summary>
public class Blog : ViewComponent
{
    /// <summary>
    /// Invokes a component.
    /// </summary>
    /// <param name="posts">Blog posts.</param>
    /// <returns>View with posts.</returns>
    public IViewComponentResult Invoke(PaginatedList<Post> posts)
    {
        return View(nameof(Blog), posts);
    }
}
