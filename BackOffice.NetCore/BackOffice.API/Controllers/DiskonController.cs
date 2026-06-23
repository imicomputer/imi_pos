using BackOffice.API.Data;
using BackOffice.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DiskonController : ControllerBase
{
    private readonly PosDbContext _context;

    public DiskonController(PosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Diskon>>> GetDiskon([FromQuery] string? nama = null)
    {
        var query = _context.Diskon.AsQueryable();

        if (!string.IsNullOrEmpty(nama))
            query = query.Where(d => EF.Functions.Like(d.Nama!, $"%{nama}%"));

        var diskon = await query.ToListAsync();
        return Ok(diskon);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Diskon>> GetDiskon(int id)
    {
        var diskon = await _context.Diskon.FindAsync(id);

        if (diskon == null)
            return NotFound();

        return Ok(diskon);
    }

    [HttpPost]
    public async Task<ActionResult<Diskon>> CreateDiskon(Diskon diskon)
    {
        _context.Diskon.Add(diskon);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDiskon), new { id = diskon.Id }, diskon);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDiskon(int id, Diskon diskon)
    {
        if (id != diskon.Id)
            return BadRequest();

        _context.Entry(diskon).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Diskon.AnyAsync(d => d.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiskon(int id)
    {
        var diskon = await _context.Diskon.FindAsync(id);
        if (diskon == null)
            return NotFound();

        _context.Diskon.Remove(diskon);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

// Made with Bob
