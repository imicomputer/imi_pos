using BackOffice.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LaporanController : ControllerBase
{
    private readonly PosDbContext _context;

    public LaporanController(PosDbContext context)
    {
        _context = context;
    }

    [HttpGet("penjualan")]
    public async Task<IActionResult> GetLaporanPenjualan(
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null)
    {
        var query = _context.Faktur
            .Include(f => f.FakturDetails)
            .ThenInclude(fd => fd.Produk)
            .AsQueryable();

        if (startDate.HasValue)
            query = query.Where(f => f.TglFaktur >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(f => f.TglFaktur <= endDate.Value);

        var faktur = await query
            .OrderByDescending(f => f.TglFaktur)
            .ToListAsync();

        var result = faktur.Select(f => new
        {
            f.NoFaktur,
            f.TglFaktur,
            f.AtasNama,
            f.DgnTelp,
            f.NamaUser,
            TotalPenjualan = f.FakturDetails.Sum(fd => fd.TotStlhDiskon),
            JumlahItem = f.FakturDetails.Count,
            Details = f.FakturDetails.Select(fd => new
            {
                fd.IdProduk,
                NamaProduk = fd.Produk?.Nama,
                fd.Harga,
                fd.JmlBeli,
                fd.Total,
                fd.Diskon,
                fd.TotStlhDiskon,
                fd.Free
            })
        });

        return Ok(result);
    }

    [HttpGet("penjualan/summary")]
    public async Task<IActionResult> GetSummaryPenjualan(
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null)
    {
        var query = _context.FakturDetail
            .Include(fd => fd.Faktur)
            .Include(fd => fd.Produk)
            .AsQueryable();

        if (startDate.HasValue)
            query = query.Where(fd => fd.Faktur!.TglFaktur >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(fd => fd.Faktur!.TglFaktur <= endDate.Value);

        var details = await query.ToListAsync();

        var summary = new
        {
            TotalTransaksi = details.Select(d => d.NoFaktur).Distinct().Count(),
            TotalPenjualan = details.Sum(d => d.TotStlhDiskon),
            TotalDiskon = details.Sum(d => d.Diskon),
            TotalItemTerjual = details.Sum(d => d.JmlBeli),
            ProdukTerlaris = details
                .GroupBy(d => new { d.IdProduk, d.Produk!.Nama })
                .Select(g => new
                {
                    IdProduk = g.Key.IdProduk,
                    NamaProduk = g.Key.Nama,
                    JumlahTerjual = g.Sum(d => d.JmlBeli),
                    TotalPenjualan = g.Sum(d => d.TotStlhDiskon)
                })
                .OrderByDescending(p => p.JumlahTerjual)
                .Take(10)
        };

        return Ok(summary);
    }
}

// Made with Bob
