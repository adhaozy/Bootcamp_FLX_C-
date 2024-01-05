using System.Linq.Expressions;
using WebMVC.Data;
using WebMVC.Models;
using WebMVC.Models.Repository;

namespace WebMVC.Persistence.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly MyDatabase _db;
		public CategoryRepository(MyDatabase db) : base(db)
		{
			_db = db;
		}

		public Task SaveAsync()
		{
			return _db.SaveChangesAsync();
		}

		public void Update(Category category)
		{
			_db.Update(category);
		}
	}
}