using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using API.Model;

namespace API.Data;

public class MyDatabase : DbContext
{
    public MyDatabase(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Category> Categories {get; set;}
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>(cat =>
        {
            cat.HasKey(c => c.CategoryId);
			cat.Property(c => c.CategoryName).IsRequired(true);
			cat.Property(c => c.Description).IsRequired(false);
			cat.HasMany(c => c.Products).WithOne(p => p.Category);

        });
        modelBuilder.Entity<Product>(pro =>
		{
			pro.HasKey(c => c.ProductId);
			pro.Property(c => c.ProductName).IsRequired(true);
			pro.Property(c => c.Description).IsRequired(false);
		});
		modelBuilder.Entity<Category>().HasData
		(
			new Category() 
			{
				CategoryId = 1,
				CategoryName = "Electronic",
				Description = "Ini electronic"
			},
			new Category() 
			{
				CategoryId = 2,
				CategoryName = "Fruit",
				Description = "Ini Fruit"
			}
		);
		modelBuilder.Entity<Product>().HasData
		(
			new Product() 
			{
				ProductId = 1,
				ProductName = "TV",
				Description = "Ini TV",
				CategoryId = 1
			},
			new Product() 
			{
				ProductId = 2,
				ProductName = "HP",
				Description = "Ini HP",
				CategoryId = 1
			}
		);
    }
}