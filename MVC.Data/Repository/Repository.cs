using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebMVC.Data;

namespace WebMVC.Models.Repository;

public class Repository<T> : IRepository<T> where T : class
{
	private readonly MyDatabase _db;
	private DbSet<T> _set;
	public Repository(MyDatabase db) 
	{
		_db = db;
		_set = _db.Set<T>();
	}
	public void Add(T entity)
	{
		_set.Add(entity);
	}

	public async Task<T> Get(Guid id)
	{
		return await _set.FindAsync(id);
	}

	public async Task<IEnumerable<T>> GetAll()
	{
		return await _set.ToListAsync();
	}

	public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression, string include = null)
	{
		if(!String.IsNullOrEmpty(include)) 
		{
			_set.Include(include);
		}
		IQueryable<T> query = _set.Where(expression);
		return await query.ToListAsync();
	}

	public void Remove(T entity)
	{
		_set.Remove(entity);
	}

	public void RemoveRange(IEnumerable<T> entities)
	{
		_set.RemoveRange(entities);
	}
}