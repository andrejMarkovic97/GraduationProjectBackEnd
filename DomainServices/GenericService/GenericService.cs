using AutoMapper;
using DataAccess.GenericRepository;

namespace Application.GenericService;

public class GenericService<TEntity> : IGenericService<TEntity>
    where TEntity : class
{
    private readonly IGenericRepository<TEntity> _repository; 

    public GenericService(IGenericRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public virtual async Task CreateAsync(TEntity entity)
    {
        await _repository.AddAsync(entity);
       
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
        
    }
}
