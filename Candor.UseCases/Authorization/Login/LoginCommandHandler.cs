using System.Security.Authentication;
using Candor.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Authorization.Login;
internal class LoginCommandHandler : AsyncRequestHandler<LoginCommand>
{
    private readonly SignInManager<User> signInManager;
    private readonly ILogger<LoginCommandHandler> logger;

    public LoginCommandHandler(SignInManager<User> signInManager, ILogger<LoginCommandHandler> logger)
    {
        this.signInManager = signInManager;
        this.logger = logger;
    }

    protected override async Task Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginResult = await signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

        if (!loginResult.Succeeded)
        {
            var exception = new AuthenticationException("Incorrect username or password");
            logger.LogError($"Login error: {exception.Message}");
            throw exception;
        }

        logger.LogInformation($"Signed in: {request.Username}");
    }
}
