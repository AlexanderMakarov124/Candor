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
    /// The date when a post was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// User who owns the blog post.
    /// </summary>
    public virtual User User { get; init; }

    /// <summary>
    /// Id of user who owns the blog post.
    /// </summary>
    public virtual string UserId { get; init; }
}
