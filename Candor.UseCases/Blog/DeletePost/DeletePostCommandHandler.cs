using Candor.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.DeletePost;

/// <summary>
/// Delete post command handler.
/// </summary>
internal class DeletePostCommandHandler : AsyncRequestHandler<DeletePostCommand>
{
    private readonly ILogger<DeletePostCommandHandler> logger;
    private readonly ApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public DeletePostCommandHandler(ILogger<DeletePostCommandHandler> logger, ApplicationContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    /// <inheritdoc/>
    protected override async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        db.Remove(request.Post);
        await db.SaveChangesAsync(cancellationToken);

        logger.LogDebug("Post with id {Id} was deleted.", request.Post.Id);
    }
}
