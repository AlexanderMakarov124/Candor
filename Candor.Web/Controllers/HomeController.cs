using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Candor.UseCases.Blog.GetAllPosts;
using Candor.Web.ViewModels;
using MediatR;

namespace Candor.Web.Controllers;

/// <summary>
/// Home controller.
/// </summary>
public class HomeController : Controller
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public HomeController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    /// <summary>
    /// Main page.
    /// </summary>
    /// <returns>View.</returns>
    public async Task<IActionResult> IndexAsync(CancellationToken cancellationToken)
    {
        var posts = await mediator.Send(new GetAllPostsQuery(), cancellationToken);

        return View(posts.OrderByDescending(post => post.CreatedAt));
    }
        
    /// <summary>
    /// Error page.
    /// </summary>
    /// <returns>View.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
