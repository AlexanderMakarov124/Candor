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

    protected override Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
