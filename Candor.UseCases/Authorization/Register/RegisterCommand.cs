using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Authorization.Register;

/// <summary>
/// Register command.
/// </summary>
/// <param name="User">User to register.</param>
/// <param name="Password">User's password.</param>
public record RegisterCommand(User User, string Password) : IRequest;