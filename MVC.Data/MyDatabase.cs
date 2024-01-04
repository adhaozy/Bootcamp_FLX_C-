using Microsoft.EntityFrameworkCore;
using WebMVC.Models;

namespace WebMVC.Data;

public class MyDatabase : DbContext
{
	public DbSet<Category> Categories { get; set; }
	public MyDatabase(DbContextOptions options) : base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Category>(cat =>
		{
			cat.HasKey(c => c.CategoryId);
			cat.Property(c => c.CategoryName).IsRequired(true);
			cat.Property(c => c.Description).IsRequired(false);
		});
		//Seed Data
		modelBuilder.Entity<Category>().HasData(
			new Category() 
			{
				CategoryId = Guid.Parse("41dbeca1-e850-48a6-ab8b-6f9e4516aea5"),
				CategoryName = "Electronic"
			},
			new Category() 
			{
				CategoryId = Guid.Parse("2d049fbd-d649-464a-acea-2d84419aa7a1"),
				CategoryName = "Product"
			}
		);
	}
}
