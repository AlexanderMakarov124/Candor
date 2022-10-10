namespace Candor.Web.ViewModels.Blog;

/// <summary>
/// Create comment view model.
/// </summary>
public class CreateCommentViewModel
{
    /// <summary>
    /// Post id.
    /// </summary>
    public int PostId { get; init; }

    /// <summary>
    /// Replied comment id.
    /// </summary>
    public int CommentId { get; init; }

    /// <summary>
    /// Comment content.
    /// </summary>
    public string? Content { get; init; }
}
