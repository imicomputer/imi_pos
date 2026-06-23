using BackOffice.API.Data;
using BackOffice.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PelangganController : ControllerBase
{
    private readonly PosDbContext _context;

    public PelangganController(PosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pelanggan>>> GetPelanggan(
        [FromQuery] string? nama = null,
        [FromQuery] string? telepon = null,
        [FromQuery] string? alamat = null)
    {
        var query = _context.Pelanggan.AsQueryable();

        if (!string.IsNullOrEmpty(nama))
            query = query.Where(p => EF.Functions.Like(p.Nama!, $"%{nama}%"));

        if (!string.IsNullOrEmpty(telepon))
            query = query.Where(p => EF.Functions.Like(p.Telepon!, $"%{telepon}%"));

        if (!string.IsNullOrEmpty(alamat))
            query = query.Where(p => EF.Functions.Like(p.Alamat!, $"%{alamat}%"));

        var pelanggan = await query.ToListAsync();
        return Ok(pelanggan);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pelanggan>> GetPelanggan(int id)
    {
        var pelanggan = await _context.Pelanggan.FindAsync(id);

        if (pelanggan == null)
            return NotFound();

        return Ok(pelanggan);
    }

    [HttpPost]
    public async Task<ActionResult<Pelanggan>> CreatePelanggan(Pelanggan pelanggan)
    {
        _context.Pelanggan.Add(pelanggan);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPelanggan), new { id = pelanggan.Id }, pelanggan);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePelanggan(int id, Pelanggan pelanggan)
    {
        if (id != pelanggan.Id)
            return BadRequest();

        _context.Entry(pelanggan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Pelanggan.AnyAsync(p => p.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePelanggan(int id)
    {
        var pelanggan = await _context.Pelanggan.FindAsync(id);
        if (pelanggan == null)
            return NotFound();

        _context.Pelanggan.Remove(pelanggan);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

// Made with Bob
