using System.ComponentModel.DataAnnotations;
using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.CreatePost;

/// <summary>
/// Create post command.
/// </summary>
public record CreatePostCommand : IRequest
{
    /// <inheritdoc cref="Post.Title"/>
    [MaxLength(200)]
    public string? Title { get; init; }

    /// <inheritdoc cref="Post.Content"/>
    [DataType(DataType.MultilineText)]
    public string? Content { get; init; }

    /// <inheritdoc cref="Post.UserId"/>
    public string? UserId { get; init; }
}