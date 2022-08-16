using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Authorization.Register;
public record RegisterCommand(User User, string Password) : IRequest;