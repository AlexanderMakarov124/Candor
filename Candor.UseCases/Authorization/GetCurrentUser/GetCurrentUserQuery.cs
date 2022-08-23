using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Authorization.GetCurrentUser;

public record GetCurrentUserQuery : IRequest<User>;
