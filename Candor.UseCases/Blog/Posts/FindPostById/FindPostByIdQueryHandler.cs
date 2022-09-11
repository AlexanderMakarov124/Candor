﻿using Candor.DataAccess;
using Candor.Domain.Models;
using Candor.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.Posts.FindPostById;

/// <summary>
/// Find post by id query handler.
/// </summary>
internal class FindPostByIdQueryHandler : IRequestHandler<FindPostByIdQuery, Post>
{
    private readonly ILogger<FindPostByIdQueryHandler> logger;
    private readonly ApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
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
            logger.LogError("Post with id {Id} does not exist.", request.Id);

            throw new NotFoundException("Post was not found");
        }

        await db.Entry(post).Reference(p => p.User).LoadAsync(cancellationToken);
        await db.Entry(post)
            .Collection(p => p.Comments)
            .Query()
            .Include(c => c.User)
            .Include(c => c.Replies)
            .ThenInclude(r => r.Replies)
            .LoadAsync(cancellationToken);

        logger.LogDebug("Post with id {Id} was retrieved.", request.Id);

        return post;
    }
}