
namespace ApplicationServices.GenericApplicationService;

public interface IGenericApplicationService<TEntity, TDto>
    where TEntity : class 
    where TDto : class 
{
    Task<TDto?> GetByIdAsync(Guid id);
    Task<List<TDto>> GetAllAsync();
    Task<TDto> CreateAsync(TDto dto);
    Task<TDto> UpdateAsync(TDto dto);
    Task DeleteAsync(Guid id);
}