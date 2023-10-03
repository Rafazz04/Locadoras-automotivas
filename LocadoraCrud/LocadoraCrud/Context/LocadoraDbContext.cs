using LocadoraCrud.Models;
using Locadoras.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadoras.Context;

public class LocadoraDbContext : DbContext
{
    public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : base(options) { }

    public DbSet<Locadora> Locadoras { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Montadora> Montadoras { get; set; }
    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<VeiculoLog> VeiculoLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.ToTable("Veiculos");

            entity.HasKey(e => e.VeiculoId);

            entity.Property(e => e.NumeroPortas).HasMaxLength(10);
            entity.Property(e => e.Cor).HasMaxLength(50);
            entity.Property(e => e.Fabricante).HasMaxLength(200);
            entity.Property(e => e.AnoModelo).HasMaxLength(20);
            entity.Property(e => e.AnoFabricacao).HasMaxLength(20);
            entity.Property(e => e.Placa).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Chassi).HasMaxLength(200).IsRequired();
            entity.Property(e => e.DataCriacao).HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.Modelo)
                .WithMany(m => m.Veiculos)
                .HasForeignKey(e => e.ModeloId);

            entity.HasOne(e => e.Locadora)
                .WithMany(l => l.Veiculos)
                .HasForeignKey(e => e.LocadoraId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(e => new { e.Placa, e.Chassi }).IsUnique();
        });

        modelBuilder.Entity<Veiculo>()
            .HasOne(v => v.Locadora)
            .WithMany(l => l.Veiculos)
            .HasForeignKey(v => v.LocadoraId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Modelo>()
            .HasMany(m => m.Veiculos)
            .WithOne(v => v.Modelo)
            .HasForeignKey(v => v.ModeloId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Montadora>()
            .HasMany(m => m.Modelos)
            .WithOne(m => m.Montadora)
            .HasForeignKey(m => m.MontadoraId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
