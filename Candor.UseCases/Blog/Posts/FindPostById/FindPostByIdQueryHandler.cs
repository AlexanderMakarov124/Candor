using Candor.DataAccess;
using Candor.Domain.Models;
using Candor.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.Posts.FindPostById;

/// <summary>
/// Find post by id query handler.
/// </summary>
internal class FindPostByIdQueryHandler : IRequestHandler<FindPostByIdQuery, Post>
{
    private readonly ILogger<FindPostByIdQueryHandler> logger;
    private readonly ApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FindPostByIdQueryHandler(ILogger<FindPostByIdQueryHandler> logger, ApplicationContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    /// <inheritdoc />
    public async Task<Post> Handle(FindPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await db.Posts.FindAsync(request.Id);

        if (post == null)
        {
            logger.LogError("Post with id {Id} does not exist.", request.Id);

            throw new NotFoundException($"Post with id {request.Id} does not exist.");
        }

        await db.Entry(post).Reference(p => p.User).LoadAsync(cancellationToken);

        await db.Entry(post).Collection(p => p.Comments).LoadAsync(cancellationToken);

        await LoadAllRelatedRepliesAsync(post.Comments, cancellationToken);

        logger.LogDebug("Post with id {Id} was retrieved.", request.Id);

        return post;
    }

    private async Task LoadAllRelatedRepliesAsync(IEnumerable<Comment> comments, CancellationToken cancellationToken)
    {
        foreach (var reply in comments)
        {
            await db.Entry(reply).Reference(r => r.User).LoadAsync(cancellationToken);
            await db.Entry(reply).Collection(r => r.Replies).LoadAsync(cancellationToken);

            if (reply.Replies.Any())
            {
                await LoadAllRelatedRepliesAsync(reply.Replies, cancellationToken);
            }
        }
    }
}
