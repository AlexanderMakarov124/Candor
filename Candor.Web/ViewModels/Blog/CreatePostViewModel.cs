using Candor.Domain.Models;

namespace Candor.Web.ViewModels.Blog;

/// <summary>
/// Create post view model.
/// </summary>
public class CreatePostViewModel
{
    /// <inheritdoc cref="Post.Title"/>
    public string? Title { get; init; }

    /// <inheritdoc cref="Post.Content"/>
    public string? Content { get; init; }
}
