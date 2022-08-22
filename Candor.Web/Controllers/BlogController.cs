using System.Diagnostics;
using AutoMapper;
using Candor.UseCases.Blog.CreatePost;
using Candor.UseCases.Blog.GetAllPosts;
using Candor.UseCases.Blog.GetCurrentUser;
using Candor.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Web.Controllers;

/// <summary>
/// Blog controller.
/// </summary>
public class BlogController : Controller
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public BlogController(IMediator mediator, IMapper mapper)
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
    /// GET: User's blog page.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet("/Blog")]
    [Authorize]
    public async Task<IActionResult> UserBlogAsync(CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetCurrentUserQuery(), cancellationToken);

        return View(user.Posts.OrderByDescending(post => post.CreatedAt));
    }

    /// <summary>
    /// GET: Create post page.
    /// </summary>
    /// <returns>View.</returns>
    [Authorize]
    [HttpGet("/CreatePost")]
    public IActionResult CreatePost()
    {
        return View();
    }

    /// <summary>
    /// POST: Creates post.
    /// </summary>
    /// <param name="command">Create post command.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to user's blog.</returns>
    [HttpPost("/CreatePost")]
    [Authorize]
    public async Task<IActionResult> CreatePostAsync(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetCurrentUserQuery(), cancellationToken);

        command = command with
        {
            UserId = user.Id
        };

        await mediator.Send(command, cancellationToken);

        return RedirectToAction("UserBlog");
    }
}
