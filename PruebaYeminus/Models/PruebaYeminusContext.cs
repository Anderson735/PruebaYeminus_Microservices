using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaYeminus.Models;

public partial class PruebaYeminusContext : DbContext
{
    public PruebaYeminusContext()
    {
    }

    public PruebaYeminusContext(DbContextOptions<PruebaYeminusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ListaDePrecio> ListaDePrecios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ListaDePrecio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ListaDeP__3214EC073FF2558A");

            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.ListaDePrecios)
                .HasForeignKey(d => d.CodigoProducto)
                .HasConstraintName("FK_Productos");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Producto__06370DADA91DA6C7");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Imagen).HasMaxLength(255);
            entity.Property(e => e.ProductoParaLaVenta).HasColumnType("bit");
            entity.Property(e => e.PorcentajeIva).HasColumnType("int");

            entity.HasMany(e => e.ListaDePrecios)
                  .WithOne(p => p.CodigoProductoNavigation)
                  .HasForeignKey(p => p.CodigoProducto)
                  .HasConstraintName("FK_ListaDePrecios_Productos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
