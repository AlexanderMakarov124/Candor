using Candor.DataAccess;
using Candor.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.CreatePost;

/// <summary>
/// Create post command handler.
/// </summary>
internal class CreatePostCommandHandler : AsyncRequestHandler<CreatePostCommand>
{
    private readonly ILogger<CreatePostCommandHandler> logger;
    private readonly ApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreatePostCommandHandler(ILogger<CreatePostCommandHandler> logger, ApplicationContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    /// <inheritdoc />
    protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post { Title = request.Title, Content = request.Content, CreatedAt = DateTime.UtcNow, UserId = request.UserId };

        await db.Posts.AddAsync(post, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        logger.LogDebug("Post was created");
    }
}
