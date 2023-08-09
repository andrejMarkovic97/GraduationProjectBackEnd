namespace Application.GenericService;

public interface IGenericService<TEntityDto, TEntity> 
    where TEntity : class
    where TEntityDto : class
{
    IQueryable<TEntityDto> GetAll();
    Task<TEntityDto> GetByIdAsync(Guid id);
    Task<TEntityDto> CreateAsync(TEntityDto entityDto);
    Task UpdateAsync(TEntityDto entityDto);
    Task DeleteAsync(Guid id);
}