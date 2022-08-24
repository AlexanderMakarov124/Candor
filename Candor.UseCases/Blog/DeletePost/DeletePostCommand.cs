using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.DeletePost;

/// <summary>
/// Delete post command.
/// </summary>
/// <param name="Post">Post to delete.</param>
public record DeletePostCommand(Post Post) : IRequest;
