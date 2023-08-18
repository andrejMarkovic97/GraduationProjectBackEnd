using Application.GenericService;
using AutoMapper;

namespace ApplicationServices.GenericApplicationService;

public class GenericApplicationService<TEntity, TDto> : IGenericApplicationService<TEntity, TDto>
    where TEntity : class 
    where TDto : class 
   
{
    protected readonly IGenericService<TEntity> GenericService;
    protected readonly IMapper Mapper;

    public GenericApplicationService(IGenericService<TEntity> genericService, IMapper mapper)
    {
        GenericService = genericService;
        Mapper = mapper;
    }


    public virtual async Task<TDto?> GetByIdAsync(Guid id)
    {
        var entity = await GenericService.GetByIdAsync(id);

        return entity != null
            ? Mapper.Map<TEntity, TDto>(entity)
            : null;
    }

    public virtual async Task<List<TDto>> GetAllAsync()
    {
        var list = await GenericService.GetAllAsync();
        return Mapper.Map<List<TEntity>, List<TDto>>(list);
    }

    public virtual async Task<TDto> CreateAsync(TDto dto)
    {
        var entity = Mapper.Map<TDto, TEntity>(dto);
        await GenericService.CreateAsync(entity);
        return dto;
    }

    public virtual async Task<TDto> UpdateAsync(TDto dto)
    {
        var entity = Mapper.Map<TDto, TEntity>(dto);
        await GenericService.UpdateAsync(entity);
        return dto;
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await GenericService.DeleteAsync(id);
    }
}