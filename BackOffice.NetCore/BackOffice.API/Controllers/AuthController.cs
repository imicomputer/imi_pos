using BackOffice.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            return BadRequest(new { message = "Username and password are required" });

        var response = await _authService.LoginAsync(request.Username, request.Password);

        if (response == null)
            return Unauthorized(new { message = "Invalid credentials or insufficient permissions" });

        await _authService.UpdateLastLoginAsync(request.Username);

        return Ok(response);
    }
}

// Made with Bob
