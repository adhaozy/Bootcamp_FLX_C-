using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial;

public class MyDatabase : DbContext
{
	//Table
	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite(@"FileName=./MyDatabase.db");
	}
	protected override void OnModelCreating(ModelBuilder model)
	{
		model.Entity<Category>(category =>
		{
			category.HasKey(c => c.CategoryId);
			category.Property(c => c.CategoryName).IsRequired().HasMaxLength(20);
			category.Property(c => c.Description).HasMaxLength(100);
			category.HasMany(c => c.Products).WithOne(p => p.Category);
            // opsi 2
            //category.HasMany(c => c.Products);
		});
		model.Entity<Product>(product =>
		{
			product.HasKey(p => p.ProductId);
			product.Property(p => p.ProductName).IsRequired().HasMaxLength(20);
            // opsi 2
            //product.HasOne(p => p.Category);
			product.Property(p => p.Cost).HasColumnName("ProductPrice").HasColumnType("money");
		});
		//Seeding
		model.Entity<Category>().HasData(
			new Category() 
			{
				CategoryId = 1,
				CategoryName = "Electronic",
				Description = "Ini Electronic"
			},
			new Category() 
			{
				CategoryId = 2,
				CategoryName = "Fruit",
				Description = "Ini Fruit"
			},

            new Category()
            {
                CategoryId = 3,
                CategoryName = "Toy",
                Description = "Ini Toy"
            }

            
		);
		model.Entity<Product>().HasData(
			new Product() 
			{
				ProductId = 1,
				ProductName = "TV",
				CategoryId = 1
			},
			new Product() 
			{
				ProductId = 2,
				ProductName = "Radio",
				CategoryId = 1
			},
            new Product() 
			{
				ProductId =3,
				ProductName = "PC GAHAR",
				CategoryId = 1
			}
		);
	}
	
}
