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
    private readonly ApplicationContext db;
    private readonly ILogger<CreatePostCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="logger"></param>
    public CreatePostCommandHandler(ApplicationContext db, ILogger<CreatePostCommandHandler> logger)
    {
        this.db = db;
        this.logger = logger;
    }

    /// <inheritdoc />
    protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post { Title = request.Title, Content = request.Content, CreatedAt = DateTime.UtcNow };

        await db.Posts.AddAsync(post, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Post was created");
    }
}
