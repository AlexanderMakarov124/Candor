using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Candor.Web.ViewModels;

namespace Candor.Web.Controllers;

/// <summary>
/// Home controller.
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    /// Main page.
    /// </summary>
    /// <returns>View.</returns>
    public IActionResult Index()
    {
        return View();
    }
        
    /// <summary>
    /// Error page.
    /// </summary>
    /// <returns>View.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
