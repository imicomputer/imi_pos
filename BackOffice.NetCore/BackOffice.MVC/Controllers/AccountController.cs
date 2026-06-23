using BackOffice.MVC.Models;
using BackOffice.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.MVC.Controllers;

public class AccountController : Controller
{
    private readonly IApiClient _apiClient;

    public AccountController(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    [HttpGet]
    public IActionResult Login()
    {
        // If already logged in, redirect to home
        if (!string.IsNullOrEmpty(_apiClient.GetAuthToken()))
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            var response = await _apiClient.PostAsync<AuthResponse>("api/auth/login", new
            {
                username = model.Username,
                password = model.Password
            });

            if (response != null && !string.IsNullOrEmpty(response.Token))
            {
                _apiClient.SetAuthToken(response.Token);
                HttpContext.Session.SetString("Username", response.Username);
                HttpContext.Session.SetString("Role", response.Role);
                
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid credentials or insufficient permissions");
            return View(model);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Login failed: {ex.Message}");
            return View(model);
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}

// Made with Bob
