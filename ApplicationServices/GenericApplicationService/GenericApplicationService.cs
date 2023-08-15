using Application.GenericService;
using AutoMapper;

namespace ApplicationServices.GenericApplicationService;

public class GenericApplicationService<TEntity, TDto> : IGenericApplicationService<TEntity, TDto>
    where TEntity : class 
    where TDto : class 
   
{
    private readonly IGenericService<TEntity> _genericService;
    private readonly IMapper _mapper;

    public GenericApplicationService(IGenericService<TEntity> genericService, IMapper mapper)
    {
        _genericService = genericService;
        _mapper = mapper;
    }


    public virtual async Task<TDto?> GetByIdAsync(Guid id)
    {
        var entity = await _genericService.GetByIdAsync(id);

        return entity != null
            ? _mapper.Map<TEntity, TDto>(entity)
            : null;
    }

    public virtual async Task<List<TDto>> GetAllAsync()
    {
        var list = await _genericService.GetAllAsync();
        return _mapper.Map<List<TEntity>, List<TDto>>(list);
    }

    public virtual async Task<TDto> CreateAsync(TDto dto)
    {
        var entity = _mapper.Map<TDto, TEntity>(dto);
        await _genericService.CreateAsync(entity);
        return dto;
    }

    public virtual async Task<TDto> UpdateAsync(TDto dto)
    {
        var entity = _mapper.Map<TDto, TEntity>(dto);
        await _genericService.UpdateAsync(entity);
        return dto;
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _genericService.DeleteAsync(id);
    }
}