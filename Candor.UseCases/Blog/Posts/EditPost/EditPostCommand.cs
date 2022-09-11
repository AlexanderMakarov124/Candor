using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.Posts.EditPost;

/// <summary>
/// Edit post command.
/// </summary>
/// <param name="Post">Post to edit.</param>
public record EditPostCommand(Post Post) : IRequest
{
}