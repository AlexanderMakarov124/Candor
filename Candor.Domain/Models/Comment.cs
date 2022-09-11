namespace Candor.Domain.Models;

/// <summary>
/// Comment to the post.
/// </summary>
public class Comment
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Content.
    /// </summary>
    public string Content { get; init; }

    /// <summary>
    /// User who wrote the comment.
    /// </summary>
    public User User { get; init; }

    /// <summary>
    /// Date when comment was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// The comment is reply to this comment. If null this comment is not reply.
    /// </summary>
    public Comment CommentReply { get; init; }

    /// <summary>
    /// Replies to the comment.
    /// </summary>
    public ICollection<Comment> Replies { get; init; }
}
