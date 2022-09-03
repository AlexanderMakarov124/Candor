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
    public string? Title { get; set; }

    /// <summary>
    /// Content.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// The date when the post was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// User who owns the blog post.
    /// </summary>
    public virtual User? User { get; init; }

    /// <summary>
    /// Id of user who owns the blog post.
    /// </summary>
    public virtual string? UserId { get; init; }

    /// <summary>
    /// If true, the post is visible to everyone, otherwise only to the user.
    /// </summary>
    public bool IsPublic { get; init; }

    /// <summary>
    /// Describes how many times the post has been visited.
    /// </summary>
    public int ViewsCount { get; set; }
}
