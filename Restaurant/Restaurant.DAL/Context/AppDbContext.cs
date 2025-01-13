using System;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Context;
public class AppDbContext : IdentityDbContext<User>
{
	public DbSet<Product> Products { get; set; }
	public DbSet<ProductImage> ProductImages{ get; set; }
	public DbSet<Category> Categories { get; set; }

	public AppDbContext(DbContextOptions opt) : base(opt) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);

        builder.Entity<Product>()
            .HasMany(x => x.OtherImages)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        builder.Entity<Category>()
            .HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.Id);

        builder.Entity<Product>(b =>
        {
            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(32);
            b.Property(x => x.Description)
                .HasMaxLength(400);
        });

        builder.Entity<Category>(b =>
        {
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
        });
        base.OnModelCreating(builder);
    }
}

