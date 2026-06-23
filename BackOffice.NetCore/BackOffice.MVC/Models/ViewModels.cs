namespace BackOffice.MVC.Models;

public class LoginViewModel
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class AuthResponse
{
    public string Token { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}

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

public class Pelanggan
{
    public int Id { get; set; }
    public string? Nama { get; set; }
    public string? Telepon { get; set; }
    public string? Alamat { get; set; }
}

public class Pengguna
{
    public string NamaUser { get; set; } = string.Empty;
    public string PassUser { get; set; } = string.Empty;
    public string StsUser { get; set; } = string.Empty;
    public DateTime? CreationDate { get; set; }
    public DateTime? LastLogin { get; set; }
    public string? LastFormUsed { get; set; }
}

public class Diskon
{
    public int Id { get; set; }
    public string? Nama { get; set; }
    public string? Jenis { get; set; }
    public double Jml { get; set; }
}

// Made with Bob
