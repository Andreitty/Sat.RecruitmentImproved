using Sat.Recruitment.Entity.Bases;
using System.Linq.Expressions;

namespace Sat.Recruitment.Infrastructure.Interfaces.Bases
{
	public interface IBaseRepository<TEntity, TId> 
		where TEntity : BaseEntity<TId>
		where TId : struct 
	{
		Task<TEntity?> GetByIdAsync(TId id);
		Task<IReadOnlyList<TEntity>> ListAsync();
		Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);
		Task<TEntity> AddAsync(TEntity entity);
		Task DeleteAsync(TEntity entity);
		Task EditAsync(TEntity entity);
	}
}
