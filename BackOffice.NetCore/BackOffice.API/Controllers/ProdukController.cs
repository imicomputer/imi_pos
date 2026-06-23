using BackOffice.API.Data;
using BackOffice.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProdukController : ControllerBase
{
    private readonly PosDbContext _context;

    public ProdukController(PosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produk>>> GetProduk()
    {
        var produk = await _context.Produk
            .Where(p => !_context.PaketDetail.Any(pd => pd.IdProdukPaket == p.Id))
            .OrderBy(p => p.Id)
            .ToListAsync();

        return Ok(produk);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produk>> GetProduk(string id)
    {
        var produk = await _context.Produk.FindAsync(id);

        if (produk == null)
            return NotFound();

        return Ok(produk);
    }

    [HttpPost]
    public async Task<ActionResult<Produk>> CreateProduk(Produk produk)
    {
        if (await _context.Produk.AnyAsync(p => p.Id == produk.Id))
            return BadRequest(new { message = "Product ID already exists" });

        _context.Produk.Add(produk);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduk), new { id = produk.Id }, produk);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduk(string id, Produk produk)
    {
        if (id != produk.Id)
            return BadRequest();

        _context.Entry(produk).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Produk.AnyAsync(p => p.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduk(string id)
    {
        var produk = await _context.Produk.FindAsync(id);
        if (produk == null)
            return NotFound();

        _context.Produk.Remove(produk);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

// Made with Bob
