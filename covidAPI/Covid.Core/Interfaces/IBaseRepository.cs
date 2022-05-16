namespace Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> UpdateRangeAsync(IEnumerable<TEntity> listEntity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
