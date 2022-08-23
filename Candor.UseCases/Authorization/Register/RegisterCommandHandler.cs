using System.Security.Authentication;
using Candor.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Authorization.Register;

/// <summary>
/// Register command handler.
/// </summary>
internal class RegisterCommandHandler : AsyncRequestHandler<RegisterCommand>
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly ILogger<RegisterCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RegisterCommandHandler(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ILogger<RegisterCommandHandler> logger
        )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    protected override async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var createResult = await userManager.CreateAsync(request.User, request.Password);

        if (createResult.Succeeded)
        {
            await signInManager.SignInAsync(request.User, false);

            logger.LogDebug("Signed up: {UserName}", request.User.UserName);
        }
        else
        {
            var errors = string.Join(", ", createResult.Errors.Select(error => error.Description));
            logger.LogError("Register failed: {Errors}", errors);

            throw new AuthenticationException(errors);
        }
    }
}
