using Candor.DataAccess;
using Candor.Domain.Models;
using Candor.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.FindPostById;

/// <summary>
/// Find post by id query handler.
/// </summary>
internal class FindPostByIdQueryHandler : IRequestHandler<FindPostByIdQuery, Post>
{
    private readonly ILogger<FindPostByIdQueryHandler> logger;
    private readonly ApplicationContext db;

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
            var errorMessage = $"Post with id {request.Id} does not exist.";
            logger.LogError(errorMessage);

            throw new NotFoundException(errorMessage);
        }

        logger.LogDebug("Post with id {Id} was retrieved.", request.Id);

        return post;
    }
}
