using Candor.DataAccess;
using Candor.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.GetAllPosts;

/// <summary>
/// Get all posts query handler.
/// </summary>
internal class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<Post>>
{
    private readonly ILogger<GetAllPostsQueryHandler> logger;
    private readonly ApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllPostsQueryHandler(ILogger<GetAllPostsQueryHandler> logger, ApplicationContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await db.Posts.ToListAsync(cancellationToken);

        logger.LogDebug("All posts was retrieved");

        return posts;
    }
}
