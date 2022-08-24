using System.Security.Authentication;
using Candor.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Authorization.Login;

/// <summary>
/// Login command handler.
/// </summary>
internal class LoginCommandHandler : AsyncRequestHandler<LoginCommand>
{
    private readonly SignInManager<User> signInManager;
    private readonly ILogger<LoginCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public LoginCommandHandler(SignInManager<User> signInManager, ILogger<LoginCommandHandler> logger)
    {
        this.signInManager = signInManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    protected override async Task Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginResult = await signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

        if (!loginResult.Succeeded)
        {
            const string errorMessage = "Sign in failed: Incorrect username or password";
            logger.LogError(errorMessage);

            throw new AuthenticationException(errorMessage);
        }

        logger.LogDebug("Signed in: {Username}", request.Username);
    }
}
