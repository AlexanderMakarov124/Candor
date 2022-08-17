using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.GetCurrentUser;

public record GetCurrentUserQuery : IRequest<User>;
