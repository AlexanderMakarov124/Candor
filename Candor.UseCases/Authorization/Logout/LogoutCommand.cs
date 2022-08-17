using MediatR;

namespace Candor.UseCases.Authorization.Logout;

/// <summary>
/// Logout command.
/// </summary>
public record LogoutCommand : IRequest;