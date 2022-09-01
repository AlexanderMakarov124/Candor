using System.ComponentModel.DataAnnotations;
using Candor.Domain.Models;

namespace Candor.Web.ViewModels.Blog;

/// <summary>
/// Edit post view model.
/// </summary>
public class EditPostViewModel
{
    /// <inheritdoc cref="Post.Title"/>
    [Required]
    [MaxLength(200)]
    public string? Title { get; init; }

    /// <inheritdoc cref="Post.Content"/>
    [Required]
    [DataType(DataType.MultilineText)]
    public string? Content { get; init; }
}
