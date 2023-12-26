using System.Runtime.InteropServices;
using EFCoreTutorial;
using Microsoft.EntityFrameworkCore;

class Program 
{
	static async Task Main() 
	{
		using(MyDatabase db = new()) 
		{
			Database database = new Database(db);

			// var getAllCategory = await database.GetCategory();
			// foreach(var category in getAllCategory) 
			// {
			// 	Console.WriteLine($"{category.CategoryId} - {category.CategoryName} has {category.Products.Count}");
			// }
			Product product = new Product()
			{
				ProductName = "aaaaaaaaaaasdasdasdasdasdasdasdasdadsasd",
				CategoryId = 1
			};
			db.Products.Add(product);
			db.SaveChanges();
			//Add more 
           

            // Uncomment the following code to generate and display the SQL query
            var categoryQuery = db.Categories.Where(c => c.CategoryId > 10);
            string sqlQuery = categoryQuery.ToQueryString();
            Console.WriteLine($"Generated SQL Query: {sqlQuery}");
            
		}
	}
	
}
class Database 
{
	private MyDatabase _db;
	public Database(MyDatabase db) 
	{
		_db = db;
	}
	public async Task<IEnumerable<Category>> GetCategory() 
	{
		IEnumerable<Category> categories = await _db.Categories.Include(c=> c.Products).ToListAsync();
		if(categories is null) 
		{
			return Enumerable.Empty<Category>();
		}
		return categories;
	}
	public async Task<Category> GetCategory(int id) 
	{
		var category = await _db.Categories.FindAsync(id);
		return category ?? new Category() { CategoryId = 0, CategoryName = "null" };
	}
	public async Task<Category> GetCategory(string categoryName) 
	{
		var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryName.Contains(categoryName));
		return category ??  new Category() { CategoryId = 0, CategoryName = "null" }; 
        
	}

    
}