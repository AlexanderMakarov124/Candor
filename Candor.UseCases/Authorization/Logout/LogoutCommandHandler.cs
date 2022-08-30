using Candor.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Authorization.Logout;

/// <summary>
/// Logout command handler.
/// </summary>
internal class LogoutCommandHandler : AsyncRequestHandler<LogoutCommand>
{
    private readonly ILogger<LogoutCommandHandler> logger;
    private readonly SignInManager<User> signInManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public LogoutCommandHandler(ILogger<LogoutCommandHandler> logger, SignInManager<User> signInManager)
    {
        this.logger = logger;
        this.signInManager = signInManager;
    }

    /// <inheritdoc />
    protected override async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await signInManager.SignOutAsync();

        logger.LogDebug("Signed out: {UserName}", signInManager.Context.User.Identity?.Name);
    }
}
