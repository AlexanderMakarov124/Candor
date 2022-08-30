using Candor.Domain.Models;
using Candor.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Authorization.GetCurrentUser;

/// <summary>
/// Get current user query handler.
/// </summary>
internal class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, User>
{
    private readonly ILogger<GetCurrentUserQueryHandler> logger;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCurrentUserQueryHandler(
        ILogger<GetCurrentUserQueryHandler> logger,
        UserManager<User> userManager,
        SignInManager<User> signInManager
        )
    {
        this.logger = logger;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    /// <inheritdoc />
    public async Task<User> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.GetUserAsync(signInManager.Context.User);

        if (user == null)
        {
            const string errorMessage = "Current user does not exist.";
            logger.LogError(errorMessage);

            throw new NotFoundException(errorMessage);
        }

        logger.LogDebug("Current user was retrieved");

        return user;
    }
}
