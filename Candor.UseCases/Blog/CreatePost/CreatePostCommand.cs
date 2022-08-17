using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.CreatePost;

/// <summary>
/// Create post command.
/// </summary>
public record CreatePostCommand : IRequest
{
    /// <inheritdoc cref="Post.Title"/>
    public string? Title { get; init; }

    /// <inheritdoc cref="Post.Content"/>
    public string? Content { get; init; }
}