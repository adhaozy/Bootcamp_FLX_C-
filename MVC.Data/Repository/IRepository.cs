using System.Linq.Expressions;

namespace WebMVC.Models.Repository;

public interface IRepository<T> where T : class
{
	Task<T> Get(Guid id);
	Task<IEnumerable<T>> GetAll();
	Task<IEnumerable<T>> GetAll(Expression<Func<T,bool>> expression, string included);
	void Add(T entity);
	void Remove(T entity);
	void RemoveRange(IEnumerable<T> entities);
}