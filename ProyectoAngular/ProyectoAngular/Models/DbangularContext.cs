using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoAngular.Models;

public partial class DbangularContext : DbContext
{
    public DbangularContext()
    {
    }

    public DbangularContext(DbContextOptions<DbangularContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tareas__3214EC07D42CF241");

            entity.ToTable("tareas");

            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
