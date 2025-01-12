using System;
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
	
}

