using Candor.Domain.Models;
using Candor.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.FindUserById;

/// <summary>
/// Find user by id query handler.
/// </summary>
internal class FindUserByIdQueryHandler : IRequestHandler<FindUserByIdQuery, User>
{
    private readonly UserManager<User> userManager;
    private readonly ILogger<FindUserByIdQueryHandler> logger;
        
    /// <summary>
    /// Constructor.
    /// </summary>
    public FindUserByIdQueryHandler(UserManager<User> userManager, ILogger<FindUserByIdQueryHandler> logger)
    {
        this.userManager = userManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task<User> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);

        if (user == null)
        {
            var errorMessage = $"User with id {request.Id} was not found.";
            logger.LogError(errorMessage);

            throw new NotFoundException(errorMessage);
        }

        logger.LogInformation("User with id {Id} was found successfully", request.Id);

        return user;
    }
}
