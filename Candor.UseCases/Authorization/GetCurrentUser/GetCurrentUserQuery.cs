using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Authorization.GetCurrentUser;

/// <summary>
/// Get current user query.
/// </summary>
public record GetCurrentUserQuery : IRequest<User>;
