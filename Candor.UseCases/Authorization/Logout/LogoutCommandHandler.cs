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
    private readonly SignInManager<User> signInManager;
    private readonly ILogger<LogoutCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public LogoutCommandHandler(SignInManager<User> signInManager, ILogger<LogoutCommandHandler> logger)
    {
        this.signInManager = signInManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    protected override async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await signInManager.SignOutAsync();

        logger.LogDebug("Signed out: {UserName}", signInManager.Context.User.Identity?.Name);
    }
}
