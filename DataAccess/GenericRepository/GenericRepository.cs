using DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext DbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        DbContext = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<T>();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}