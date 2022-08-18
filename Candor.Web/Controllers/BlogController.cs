using AutoMapper;
using Candor.UseCases.Blog.CreatePost;
using Candor.UseCases.Blog.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Web.Controllers;

/// <summary>
/// Blog controller.
/// </summary>
[Authorize]
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
    /// GET: User's blog page.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet("/Blog")]
    public async Task<IActionResult> UserBlogAsync(CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetCurrentUserQuery(), cancellationToken);

        return View(user.Posts.OrderByDescending(post => post.CreatedAt));
    }

    /// <summary>
    /// GET: Create post page.
    /// </summary>
    /// <returns>View.</returns>
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
