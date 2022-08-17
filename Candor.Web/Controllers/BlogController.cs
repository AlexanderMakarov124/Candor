using AutoMapper;
using Candor.UseCases.Blog.CreatePost;
using Candor.UseCases.Blog.FindUserById;
using Candor.UseCases.Blog.GetCurrentUser;
using MediatR;
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
    /// User's blog page.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet("/Blog")]
    public IActionResult UserBlog()
    {
        var user = mediator.Send(new GetCurrentUserQuery(), CancellationToken.None);

        return View();
    }

    /// <summary>
    /// Create post page.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet("/CreatePost")]
    public IActionResult CreatePost()
    {
        return View();
    }

    /// <summary>
    /// Creates post.
    /// </summary>
    /// <param name="command">Create post command.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to user's blog.</returns>
    [HttpPost("/CreatePost")]
    public async Task<IActionResult> CreatePostAsync(CreatePostCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);

        return RedirectToAction("UserBlog");
    }
}
