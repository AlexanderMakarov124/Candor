using Candor.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Candor.UseCases.Authorization.Logout;
internal class LogoutCommandHandler : AsyncRequestHandler<LogoutCommand>
{
    private readonly SignInManager<User> signInManager;

    public LogoutCommandHandler(SignInManager<User> signInManager)
    {
        this.signInManager = signInManager;
    }

    protected override async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await signInManager.SignOutAsync();
    }
}
