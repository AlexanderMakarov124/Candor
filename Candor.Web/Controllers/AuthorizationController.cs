using System.Security.Authentication;
using AutoMapper;
using Candor.Domain.Models;
using Candor.UseCases.Authorization.Login;
using Candor.UseCases.Authorization.Logout;
using Candor.UseCases.Authorization.Register;
using Candor.Web.ViewModels.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Web.Controllers;

/// <summary>
/// Authorization controller.
/// </summary>
public class AuthorizationController : Controller
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthorizationController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    /// <summary>
    /// GET: Registration page.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet("/Registration")]
    public IActionResult Registration()
    {
        return View();
    }

    /// <summary>
    /// POST: Registers user.
    /// </summary>
    /// <param name="viewModel">View model with user's data.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to main page if success, otherwise registration view.</returns>
    [HttpPost("/Register")]
    public async Task<IActionResult> RegisterAsync(RegistrationViewModel viewModel, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var user = mapper.Map<User>(viewModel);
            try
            {
                await mediator.Send(new RegisterCommand(user, viewModel.Password!), cancellationToken);
                return RedirectToAction("Index", "Blog");
            }
            catch (AuthenticationException ex)
            {
                ViewData["Errors"] = ex.Message.Split(", ");
            }
        }

        return View("Registration");
    }

    /// <summary>
    /// GET: Login page.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet("/Login")]
    public IActionResult Login()
    {
        return View();
    }

    /// <summary>
    /// POST: Login user.
    /// </summary>
    /// <param name="viewModel">View model with user's data.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to main page if success, otherwise login view.</returns>
    [HttpPost("/Login")]
    public async Task<IActionResult> LoginAsync(LoginViewModel viewModel, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var command = new LoginCommand(viewModel.UserName!, viewModel.Password!);
                await mediator.Send(command, cancellationToken);
                return RedirectToAction("Index", "Blog");
            }
            catch (AuthenticationException ex)
            {
                ViewData["Error"] = ex.Message;
            }
        }

        return View("Login");
    }

    /// <summary>
    /// POST: Logout user.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to main page.</returns>
    [HttpPost("/Logout")]
    public async Task<IActionResult> LogoutAsync(CancellationToken cancellationToken)
    {
        await mediator.Send(new LogoutCommand(), cancellationToken);
        return RedirectToAction("Index", "Blog");
    }
}
