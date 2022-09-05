using AutoMapper;
using Candor.DataAccess;
using Candor.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.CreateComment;

/// <summary>
/// Create comment command handler.
/// </summary>
internal class CreateCommentCommandHandler : AsyncRequestHandler<CreateCommentCommand>
{
    private readonly ILogger<CreateCommentCommandHandler> logger;
    private readonly ApplicationContext db;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateCommentCommandHandler(ILogger<CreateCommentCommandHandler> logger, ApplicationContext db, IMapper mapper)
    {
        this.logger = logger;
        this.db = db;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    protected override async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = mapper.Map<Comment>(request);

        // await db.Comments.AddAsync(comment, cancellationToken);

        var post = request.Post;

        post!.Comments.Add(comment);
        db.Update(post);
        await db.SaveChangesAsync(cancellationToken);

        logger.LogDebug("Comment was created to the post with id {Id}", post.Id);
    }
}
