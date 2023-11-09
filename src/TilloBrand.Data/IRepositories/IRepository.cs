namespace TilloBrand.Data.IRepositories;

public interface IRepository<TEntity>
{
    public Task<bool> DeleteAsync(long id);
    public IQueryable<TEntity> SelectAll();
    public Task<TEntity> SelectByIdAsync(long id);
    public Task<TEntity> InsertAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
}
