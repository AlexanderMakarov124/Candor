using Candor.DataAccess;
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
    private readonly ApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCurrentUserQueryHandler(
        ILogger<GetCurrentUserQueryHandler> logger,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ApplicationContext db
        )
    {
        this.logger = logger;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.db = db;
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

        await db.Entry(user).Collection(u => u.Posts!).LoadAsync(cancellationToken);

        logger.LogDebug("Current user was retrieved");

        return user;
    }
}
