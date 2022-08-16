using MediatR;

namespace Candor.UseCases.Authorization.Login;
public record LoginCommand(string Username, string Password) : IRequest;