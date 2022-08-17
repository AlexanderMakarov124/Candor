namespace Candor.Domain.Models;

/// <summary>
/// Blog post.
/// </summary>
public class Post
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Title.
    /// </summary>
    public string? Title { get; init; }

    /// <summary>
    /// Content.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// The date when a blog was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}
