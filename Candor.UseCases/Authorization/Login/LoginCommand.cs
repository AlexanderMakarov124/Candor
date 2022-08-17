using MediatR;

namespace Candor.UseCases.Authorization.Login;

/// <summary>
/// Login command.
/// </summary>
/// <param name="Username">Username to login with.</param>
/// <param name="Password">Password to login with.</param>
public record LoginCommand(string Username, string Password) : IRequest;