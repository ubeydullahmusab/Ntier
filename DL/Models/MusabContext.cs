using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL.Models;

public partial class MusabContext : DbContext
{
    public MusabContext()
    {
    }

    public MusabContext(DbContextOptions<MusabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kisi> Kisis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-U41161M;Initial Catalog=musab;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kisi>(entity =>
        {
            entity.ToTable("kisi");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Adı).HasColumnName("adı");
            entity.Property(e => e.Cinsiyet).HasColumnName("cinsiyet");
            entity.Property(e => e.Soyadı).HasColumnName("soyadı");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
