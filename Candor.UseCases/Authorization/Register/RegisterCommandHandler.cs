using System.Security.Authentication;
using Candor.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Candor.UseCases.Authorization.Register;
internal class RegisterCommandHandler : AsyncRequestHandler<RegisterCommand>
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    public RegisterCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    protected override async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var createResult = await userManager.CreateAsync(request.User, request.Password);

        if (createResult.Succeeded)
        {
            await signInManager.SignInAsync(request.User, false);
        }
        else
        {
            var errors = string.Join(", ", createResult.Errors.Select(error => error.Description));

            throw new AuthenticationException(errors);
        }
    }
}
