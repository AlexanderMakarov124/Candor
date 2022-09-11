using Candor.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.Posts.EditPost;

/// <summary>
/// Edit post command handler.
/// </summary>
internal class EditPostCommandHandler : AsyncRequestHandler<EditPostCommand>
{
    private readonly ILogger<EditPostCommandHandler> logger;
    private readonly ApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditPostCommandHandler(ILogger<EditPostCommandHandler> logger, ApplicationContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    /// <inheritdoc />
    protected override async Task Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        db.Update(request.Post);
        await db.SaveChangesAsync(cancellationToken);

        logger.LogDebug("Post with id {Id} was edited.", request.Post.Id);
    }
}
