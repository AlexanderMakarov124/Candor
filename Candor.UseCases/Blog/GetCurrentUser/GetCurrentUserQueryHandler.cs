using Candor.Domain.Models;
using Candor.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Candor.UseCases.Blog.GetCurrentUser;
internal class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, User>
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly ILogger<GetCurrentUserQueryHandler> logger;

    public GetCurrentUserQueryHandler(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ILogger<GetCurrentUserQueryHandler> logger
        )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.logger = logger;
    }

    public async Task<User> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.GetUserAsync(signInManager.Context.User);

        if (user == null)
        {
            const string errorMessage = "Error: current user does not exist.";
            logger.LogError(errorMessage);

            throw new NotFoundException(errorMessage);
        }

        logger.LogInformation("Current user was retrieved");

        return user;
    }
}
