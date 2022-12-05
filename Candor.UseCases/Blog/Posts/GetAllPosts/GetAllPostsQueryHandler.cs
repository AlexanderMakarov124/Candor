using Candor.DataAccess;
using Candor.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.Posts.GetAllPosts;

/// <summary>
/// Get all posts query handler.
/// </summary>
internal class GetAllPostsQueryHandler : RequestHandler<GetAllPostsQuery, IQueryable<Post>>
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
    protected override IQueryable<Post> Handle(GetAllPostsQuery request)
    {
        var posts = db.Posts.Include(post => post.User).Select(p => p);

        logger.LogDebug("All posts was retrieved");

        return posts;
    }
}
