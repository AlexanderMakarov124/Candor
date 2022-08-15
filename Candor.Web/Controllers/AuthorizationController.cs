using AutoMapper;
using Candor.Domain.Models;
using Candor.UseCases.Authorization.Register;
using Candor.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Web.Controllers;

public class AuthorizationController : Controller
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegistrationViewModel viewModel, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(viewModel);
        await mediator.Send(new RegisterCommand(user), cancellationToken);

        return RedirectToPage("Index");
    }
}
