using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BiblioEntity.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__Genero__E76DD66ED293DA87");

            entity.ToTable("Genero");

            entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");
            entity.Property(e => e.Genero1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Genero");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libros__FFFE464077102183");

            entity.Property(e => e.IdLibro).HasColumnName("Id_Libro");
            entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.oGenero).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK_Genero");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
