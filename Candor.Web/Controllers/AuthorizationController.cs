using System.Security.Authentication;
using AutoMapper;
using Candor.Domain.Models;
using Candor.UseCases.Authorization.Login;
using Candor.UseCases.Authorization.Logout;
using Candor.UseCases.Authorization.Register;
using Candor.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Web.Controllers;

public class AuthorizationController : Controller
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public AuthorizationController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet("/Registration")]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost("/Register")]
    public async Task<IActionResult> RegisterAsync(RegistrationViewModel viewModel, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var user = mapper.Map<User>(viewModel);
            try
            {
                await mediator.Send(new RegisterCommand(user, viewModel.Password), cancellationToken);
                return LocalRedirect("/");
            }
            catch (AuthenticationException ex)
            {
                ViewData["Errors"] = ex.Message.Split(", ");
            }
        }

        return View("Registration");

    }

    [HttpGet("/Login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("/Login")]
    public async Task<IActionResult> LoginAsync(LoginViewModel viewModel, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var command = new LoginCommand(viewModel.UserName, viewModel.Password);
                await mediator.Send(command, cancellationToken);
                return LocalRedirect("/");
            }
            catch (AuthenticationException ex)
            {
                ViewData["Error"] = ex.Message;
                
            }
        }

        return View("Login");

    }

    [HttpPost("/Logout")]
    public async Task<IActionResult> LogoutAsync(CancellationToken cancellationToken)
    {
        await mediator.Send(new LogoutCommand(), cancellationToken);
        return RedirectToAction("Index", "Home");
    }
}
