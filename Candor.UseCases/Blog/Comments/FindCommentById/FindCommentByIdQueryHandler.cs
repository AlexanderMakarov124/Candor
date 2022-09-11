using Candor.DataAccess;
using Candor.Domain.Models;
using Candor.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.Comments.FindCommentById;

/// <summary>
/// Find comment by id query handler.
/// </summary>
internal class FindCommentByIdQueryHandler : IRequestHandler<FindCommentByIdQuery, Comment>
{
    private readonly ILogger<FindCommentByIdQueryHandler> logger;
    private readonly ApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FindCommentByIdQueryHandler(ILogger<FindCommentByIdQueryHandler> logger, ApplicationContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    /// <inheritdoc />
    public async Task<Comment> Handle(FindCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment = await db.Comments.FindAsync(request.Id);

        if (comment == null)
        {
            logger.LogError("Comment with id {Id} does not exist.", request.Id);

            throw new NotFoundException("Comment was not found");
        }

        await db.Entry(comment).Collection(c => c.Replies).LoadAsync(cancellationToken);

        logger.LogDebug("Comment with id {Id} was retrieved.", request.Id);

        return comment;
    }
}
