using Candor.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Web.Views.Components;

public class BlogViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IEnumerable<Post> posts)
    {
        return View("Blog", posts);
    }
}
