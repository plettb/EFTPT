using Microsoft.EntityFrameworkCore;

namespace TptApp.Models;

internal partial class TptContext : DbContext
{
    public TptContext(DbContextOptions<TptContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.ToTable("Buyers");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasOne(d => d.Buyer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_Sales_Buyers");

            entity.HasOne(d => d.Seller).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_Sales_Sellers");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contacts");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.ToTable("Sellers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
