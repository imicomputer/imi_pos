using BackOffice.API.Data;
using BackOffice.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackOffice.API.Services;

public interface IAuthService
{
    Task<AuthResponse?> LoginAsync(string username, string password);
    Task<bool> UpdateLastLoginAsync(string username);
}

public class AuthService : IAuthService
{
    private readonly PosDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(PosDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<AuthResponse?> LoginAsync(string username, string password)
    {
        var user = await _context.Pengguna
            .FirstOrDefaultAsync(u => u.NamaUser == username);

        if (user == null || user.PassUser != password)
            return null;

        // Check if user has admin or supervisor role
        if (user.StsUser.ToLower() != "admin" && user.StsUser.ToLower() != "supervisor")
            return null;

        var token = GenerateJwtToken(user);

        return new AuthResponse
        {
            Token = token,
            Username = user.NamaUser,
            Role = user.StsUser
        };
    }

    public async Task<bool> UpdateLastLoginAsync(string username)
    {
        var user = await _context.Pengguna.FindAsync(username);
        if (user == null)
            return false;

        user.LastLogin = DateTime.Now;
        user.LastFormUsed = "back_office";
        await _context.SaveChangesAsync();
        return true;
    }

    private string GenerateJwtToken(Pengguna user)
    {
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "YourSecretKeyHere123456789012345678901234567890"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.NamaUser),
            new Claim(ClaimTypes.Role, user.StsUser),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"] ?? "BackOfficeAPI",
            audience: _configuration["Jwt:Audience"] ?? "BackOfficeMVC",
            claims: claims,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class AuthResponse
{
    public string Token { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

// Made with Bob
