using BackOffice.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IApiClient _apiClient;

    public HomeController(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public IActionResult Index()
    {
        // Check if user is authenticated
        if (string.IsNullOrEmpty(_apiClient.GetAuthToken()))
            return RedirectToAction("Login", "Account");

        ViewBag.Username = HttpContext.Session.GetString("Username");
        ViewBag.Role = HttpContext.Session.GetString("Role");
        
        return View();
    }
}

// Made with Bob
