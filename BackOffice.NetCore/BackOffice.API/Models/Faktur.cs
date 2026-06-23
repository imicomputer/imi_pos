namespace BackOffice.API.Models;

public class Faktur
{
    public string NoFaktur { get; set; } = string.Empty;
    public DateTime? TglFaktur { get; set; }
    public string? AtasNama { get; set; }
    public string? DgnTelp { get; set; }
    public string? NamaUser { get; set; }
    
    public ICollection<FakturDetail> FakturDetails { get; set; } = new List<FakturDetail>();
}

public class FakturDetail
{
    public int IdFakTreatment { get; set; }
    public string? NoFaktur { get; set; }
    public string? IdProduk { get; set; }
    public int Harga { get; set; }
    public int JmlBeli { get; set; }
    public int Total { get; set; }
    public int Diskon { get; set; }
    public int TotStlhDiskon { get; set; }
    public int Free { get; set; }
    
    public Faktur? Faktur { get; set; }
    public Produk? Produk { get; set; }
}

public class PaketDetail
{
    public int Id { get; set; }
    public string IdProdukPaket { get; set; } = string.Empty;
    public string? IdProduk { get; set; }
    public int Jumlah { get; set; }
}

// Made with Bob
