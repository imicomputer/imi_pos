using BackOffice.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.API.Data;

public class PosDbContext : DbContext
{
    public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
    {
    }

    public DbSet<Pengguna> Pengguna { get; set; }
    public DbSet<Produk> Produk { get; set; }
    public DbSet<Pelanggan> Pelanggan { get; set; }
    public DbSet<Diskon> Diskon { get; set; }
    public DbSet<Faktur> Faktur { get; set; }
    public DbSet<FakturDetail> FakturDetail { get; set; }
    public DbSet<PaketDetail> PaketDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Pengguna configuration
        modelBuilder.Entity<Pengguna>(entity =>
        {
            entity.ToTable("pengguna");
            entity.HasKey(e => e.NamaUser);
            entity.Property(e => e.NamaUser).HasColumnName("nama_user").HasMaxLength(10);
            entity.Property(e => e.PassUser).HasColumnName("pass_user").HasMaxLength(10);
            entity.Property(e => e.StsUser).HasColumnName("sts_user").HasMaxLength(10);
            entity.Property(e => e.CreationDate).HasColumnName("creation_date");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LastFormUsed).HasColumnName("last_form_used").HasMaxLength(255);
        });

        // Produk configuration
        modelBuilder.Entity<Produk>(entity =>
        {
            entity.ToTable("produk");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").HasMaxLength(10);
            entity.Property(e => e.Nama).HasColumnName("nama").HasMaxLength(50).IsRequired();
            entity.Property(e => e.Biaya).HasColumnName("biaya").IsRequired();
            entity.Property(e => e.Ket).HasColumnName("ket").HasMaxLength(255);
            entity.Property(e => e.DiskonJmlMax).HasColumnName("diskon_jml_max").HasDefaultValue(0);
            entity.Property(e => e.DiskonJml).HasColumnName("diskon_jml").HasDefaultValue(0);
            entity.Property(e => e.Stok).HasColumnName("stok").HasDefaultValue(0);
            entity.Property(e => e.PengurangStok).HasColumnName("pengurang_stok").HasDefaultValue(false);
        });

        // Pelanggan configuration
        modelBuilder.Entity<Pelanggan>(entity =>
        {
            entity.ToTable("pelanggan");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            entity.Property(e => e.Nama).HasColumnName("nama").HasMaxLength(50);
            entity.Property(e => e.Telepon).HasColumnName("telepon").HasMaxLength(14);
            entity.Property(e => e.Alamat).HasColumnName("alamat").HasMaxLength(200);
        });

        // Diskon configuration
        modelBuilder.Entity<Diskon>(entity =>
        {
            entity.ToTable("diskon");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            entity.Property(e => e.Nama).HasColumnName("nama").HasMaxLength(50);
            entity.Property(e => e.Jenis).HasColumnName("jenis").HasMaxLength(10);
            entity.Property(e => e.Jml).HasColumnName("jml");
        });

        // Faktur configuration
        modelBuilder.Entity<Faktur>(entity =>
        {
            entity.ToTable("faktur");
            entity.HasKey(e => e.NoFaktur);
            entity.Property(e => e.NoFaktur).HasColumnName("no_faktur").HasMaxLength(16);
            entity.Property(e => e.TglFaktur).HasColumnName("tgl_faktur");
            entity.Property(e => e.AtasNama).HasColumnName("atas_nama").HasMaxLength(30);
            entity.Property(e => e.DgnTelp).HasColumnName("dgn_telp").HasMaxLength(14);
            entity.Property(e => e.NamaUser).HasColumnName("nama_user").HasMaxLength(20);
        });

        // FakturDetail configuration
        modelBuilder.Entity<FakturDetail>(entity =>
        {
            entity.ToTable("faktur_detail");
            entity.HasKey(e => e.IdFakTreatment);
            entity.Property(e => e.IdFakTreatment).HasColumnName("Id_fak_treatment").ValueGeneratedOnAdd();
            entity.Property(e => e.NoFaktur).HasColumnName("no_faktur").HasMaxLength(16);
            entity.Property(e => e.IdProduk).HasColumnName("id_produk").HasMaxLength(10);
            entity.Property(e => e.Harga).HasColumnName("harga");
            entity.Property(e => e.JmlBeli).HasColumnName("jml_beli");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Diskon).HasColumnName("diskon");
            entity.Property(e => e.TotStlhDiskon).HasColumnName("tot_stlh_diskon");
            entity.Property(e => e.Free).HasColumnName("free").HasDefaultValue(0);

            entity.HasOne(d => d.Faktur)
                .WithMany(p => p.FakturDetails)
                .HasForeignKey(d => d.NoFaktur)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Produk)
                .WithMany()
                .HasForeignKey(d => d.IdProduk)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // PaketDetail configuration
        modelBuilder.Entity<PaketDetail>(entity =>
        {
            entity.ToTable("paket_detail");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.IdProdukPaket).HasColumnName("id_produk_paket").HasMaxLength(10).IsRequired();
            entity.Property(e => e.IdProduk).HasColumnName("id_produk").HasMaxLength(10);
            entity.Property(e => e.Jumlah).HasColumnName("jumlah");
        });
    }
}

// Made with Bob
