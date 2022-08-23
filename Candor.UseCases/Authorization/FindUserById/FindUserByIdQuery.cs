using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Authorization.FindUserById;

/// <summary>
/// Find user by id query.
/// </summary>
/// <param name="Id">User's id.</param>
public record FindUserByIdQuery(string Id) : IRequest<User>;
