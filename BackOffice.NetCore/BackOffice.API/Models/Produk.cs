namespace BackOffice.API.Models;

public class Produk
{
    public string Id { get; set; } = string.Empty;
    public string Nama { get; set; } = string.Empty;
    public double Biaya { get; set; }
    public string? Ket { get; set; }
    public int DiskonJmlMax { get; set; }
    public int DiskonJml { get; set; }
    public double Stok { get; set; }
    public bool PengurangStok { get; set; }
}

// Made with Bob
