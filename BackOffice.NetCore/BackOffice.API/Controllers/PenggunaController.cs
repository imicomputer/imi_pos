using BackOffice.API.Data;
using BackOffice.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.API.Controllers;

[Authorize(Roles = "admin")]
[ApiController]
[Route("api/[controller]")]
public class PenggunaController : ControllerBase
{
    private readonly PosDbContext _context;

    public PenggunaController(PosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pengguna>>> GetPengguna()
    {
        var pengguna = await _context.Pengguna.ToListAsync();
        return Ok(pengguna);
    }

    [HttpGet("{namaUser}")]
    public async Task<ActionResult<Pengguna>> GetPengguna(string namaUser)
    {
        var pengguna = await _context.Pengguna.FindAsync(namaUser);

        if (pengguna == null)
            return NotFound();

        return Ok(pengguna);
    }

    [HttpPost]
    public async Task<ActionResult<Pengguna>> CreatePengguna(Pengguna pengguna)
    {
        if (await _context.Pengguna.AnyAsync(p => p.NamaUser == pengguna.NamaUser))
            return BadRequest(new { message = "Username already exists" });

        pengguna.CreationDate = DateTime.Now;
        _context.Pengguna.Add(pengguna);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPengguna), new { namaUser = pengguna.NamaUser }, pengguna);
    }

    [HttpPut("{namaUser}")]
    public async Task<IActionResult> UpdatePengguna(string namaUser, Pengguna pengguna)
    {
        if (namaUser != pengguna.NamaUser)
            return BadRequest();

        var existingUser = await _context.Pengguna.FindAsync(namaUser);
        if (existingUser == null)
            return NotFound();

        existingUser.PassUser = pengguna.PassUser;
        existingUser.StsUser = pengguna.StsUser;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Pengguna.AnyAsync(p => p.NamaUser == namaUser))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{namaUser}")]
    public async Task<IActionResult> DeletePengguna(string namaUser)
    {
        var pengguna = await _context.Pengguna.FindAsync(namaUser);
        if (pengguna == null)
            return NotFound();

        _context.Pengguna.Remove(pengguna);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

// Made with Bob
