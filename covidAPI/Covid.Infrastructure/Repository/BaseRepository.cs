
using Core.Data;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = _dbContext.Set<TEntity>().AsQueryable().ToList();
            return query;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContext.ChangeTracker.Clear();
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        
        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entity)
        {
            _dbContext.Set<TEntity>().AddRange(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity) 
        {

            _dbContext.Set<TEntity>().Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;

        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {

            _dbContext.Update(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;

        }
        
        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<TEntity> listEntity)
        {
            _dbContext.UpdateRange(listEntity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
