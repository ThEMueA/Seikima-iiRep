using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Seikima_ii.Models;

namespace Seikima_ii.Data;

public partial class SeikimatsuContext : DbContext
{
    public SeikimatsuContext()
    {
    }

    public SeikimatsuContext(DbContextOptions<SeikimatsuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Concert> Concerts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<GoodDeal> GoodDeals { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Seikimatsu;TrustServerCertificate=True;Data Source=DESKTOP-UI0UOGH");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concert>(entity =>
        {
            entity.HasKey(e => e.ConcertId).HasName("PK__concerts__9517B78E566C3160");

            entity.Property(e => e.ConcertId).ValueGeneratedNever();
            entity.Property(e => e.CountryCode).IsFixedLength();

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Concerts).HasConstraintName("FK__concerts__countr__398D8EEE");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode).HasName("PK__Country__3436E9A4F6AF9CEC");

            entity.Property(e => e.CountryCode).IsFixedLength();
            entity.Property(e => e.TimeZone).IsFixedLength();
        });

        modelBuilder.Entity<GoodDeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__goodDeal__3213E83F6D7D679F");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__46596229FAC0F132");

            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Item).WithMany(p => p.Orders).HasConstraintName("FK__orders__item_id__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasConstraintName("FK__orders__user_id___403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FC39079E8");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
