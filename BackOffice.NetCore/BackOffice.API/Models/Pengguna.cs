namespace BackOffice.API.Models;

public class Pengguna
{
    public string NamaUser { get; set; } = string.Empty;
    public string PassUser { get; set; } = string.Empty;
    public string StsUser { get; set; } = string.Empty;
    public DateTime? CreationDate { get; set; }
    public DateTime? LastLogin { get; set; }
    public string? LastFormUsed { get; set; }
}

// Made with Bob
