using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.CreateComment;

/// <summary>
/// Command that creates comment.
/// </summary>
public record CreateCommentCommand : IRequest
{
    /// <summary>
    /// Content.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Post where comment will be created.
    /// </summary>
    public Post? Post { get; init; }

    /// <summary>
    /// The comment will be created by this user.
    /// </summary>
    public User? User { get; init; }
}
