using Candor.Infrastructure.Common.Exceptions;
using Candor.UseCases.Authorization.GetCurrentUser;
using Candor.UseCases.Blog.CreatePost;
using Candor.UseCases.Blog.DeletePost;
using Candor.UseCases.Blog.EditPost;
using Candor.UseCases.Blog.FindPostById;
using Candor.UseCases.Blog.GetAllPosts;
using Candor.Web.ViewModels.Blog;
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

    /// <summary>
    /// Constructor.
    /// </summary>
    public BlogController(IMediator mediator)
    {
        this.mediator = mediator;
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

        return View(user.Posts!.OrderByDescending(post => post.CreatedAt));
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

    /// <summary>
    /// GET: Post page.
    /// </summary>
    /// <param name="id">Post id.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>View.</returns>
    [HttpGet("/Post/{id:int}")]
    public async Task<IActionResult> PostAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var post = await mediator.Send(new FindPostByIdQuery(id), cancellationToken);

            return View(post);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// GET: Edit post page.
    /// </summary>
    /// <param name="id">Post id.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>View.</returns>
    [HttpGet("/Post/{id:int}/Edit")]
    public async Task<IActionResult> EditPostAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var post = await mediator.Send(new FindPostByIdQuery(id), cancellationToken);

            return View(post);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// POST: Edit post.
    /// </summary>
    /// <param name="id">Post id.</param>
    /// <param name="viewModel">View model.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to the post.</returns>
    [HttpPost("/Post/{id:int}/Edit")]
    public async Task<IActionResult> EditPostAsync(int id, [FromForm] EditPostViewModel viewModel, CancellationToken cancellationToken)
    {
        var post = await mediator.Send(new FindPostByIdQuery(id), cancellationToken);

        post.Title = viewModel.Title;
        post.Content = viewModel.Content;

        await mediator.Send(new EditPostCommand(post), cancellationToken);

        return LocalRedirect($"/Post/{id}");
    }

    /// <summary>
    /// DELETE: Delete post.
    /// </summary>
    /// <param name="id">Post id.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to user's blog.</returns>
    [HttpPost("/Post/{id:int}")]
    public async Task<IActionResult> DeletePostAsync(int id, CancellationToken cancellationToken)
    {
        var post = await mediator.Send(new FindPostByIdQuery(id), cancellationToken);

        await mediator.Send(new DeletePostCommand(post), cancellationToken);

        return RedirectToAction("UserBlog");
    }
}
