using AutoMapper;
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
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreatePostCommandHandler(ILogger<CreatePostCommandHandler> logger, ApplicationContext db, IMapper mapper)
    {
        this.logger = logger;
        this.db = db;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = mapper.Map<Post>(request);

        await db.Posts.AddAsync(post, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        logger.LogDebug("Post was created");
    }
}
