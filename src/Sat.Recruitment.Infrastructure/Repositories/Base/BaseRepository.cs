using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Entity.Bases;
using Sat.Recruitment.Infrastructure.Interfaces.Bases;
using System.Linq.Expressions;
using Sat.Recruitment.Infrastructure.Data;

namespace Sat.Recruitment.Infrastructure.Repositories.Base
{
	public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> 
		where TEntity : BaseEntity<TId> 
        where TId :struct
    {
	    private readonly SatRecruitmentContext _context;
	    public BaseRepository(SatRecruitmentContext context)
	    {
		    this._context = context;
	    }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
	        return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
	        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
	        _context.Set<TEntity>().Add(entity);
	        await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
	        _context.Set<TEntity>().Remove(entity);
	        await _context.SaveChangesAsync();
        }

        public async Task EditAsync(TEntity entity)
        {
	        _context.Set<TEntity>().Update(entity);
	        await _context.SaveChangesAsync();
        }
    }
}
