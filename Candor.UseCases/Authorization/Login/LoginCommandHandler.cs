using System.Security.Authentication;
using Candor.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Candor.UseCases.Authorization.Login;
internal class LoginCommandHandler : AsyncRequestHandler<LoginCommand>
{
    private readonly SignInManager<User> signInManager;

    public LoginCommandHandler(SignInManager<User> signInManager)
    {
        this.signInManager = signInManager;
    }

    protected override async Task Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginResult = await signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

        if (!loginResult.Succeeded)
        {
            throw new AuthenticationException("Incorrect username or password");
        }
    }
}
