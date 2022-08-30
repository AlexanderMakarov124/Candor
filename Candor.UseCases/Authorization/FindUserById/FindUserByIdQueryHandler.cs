using Candor.Domain.Models;
using Candor.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Authorization.FindUserById;

/// <summary>
/// Find user by id query handler.
/// </summary>
internal class FindUserByIdQueryHandler : IRequestHandler<FindUserByIdQuery, User>
{
    private readonly ILogger<FindUserByIdQueryHandler> logger;
    private readonly UserManager<User> userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FindUserByIdQueryHandler( ILogger<FindUserByIdQueryHandler> logger, UserManager<User> userManager)
    {
        this.logger = logger;
        this.userManager = userManager;
    }

    /// <inheritdoc />
    public async Task<User> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);

        if (user == null)
        {
            logger.LogError("User with id {Id} was not found.", request.Id);

            throw new NotFoundException("User was not found");
        }

        logger.LogDebug("User with id {Id} was found successfully", request.Id);

        return user;
    }
}
