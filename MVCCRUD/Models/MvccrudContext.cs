using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCRUD.Models;

public partial class MvccrudContext : DbContext
{
    public MvccrudContext()
    {
    }

    public MvccrudContext(DbContextOptions<MvccrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aprendix> Aprendices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=localhost; database=MVCCRUD; integrated security=true; TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aprendix>(entity =>
        {
            entity.HasKey(e => e.IDaprendiz).HasName("PK__APRENDIC__56564FF850A116CB");

            entity.ToTable("APRENDICES");

            entity.Property(e => e.IDaprendiz).HasColumnName("iDaprendiz");
            entity.Property(e => e.ApellidoAprendiz)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellidoAprendiz");
            entity.Property(e => e.NombreAprendiz)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombreAprendiz");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
