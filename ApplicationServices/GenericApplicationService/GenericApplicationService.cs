
using AutoMapper;
using DataAccess.GenericRepository;

namespace ApplicationServices.GenericApplicationService;

public class GenericApplicationService<TEntity, TDto> : IGenericApplicationService<TEntity, TDto>
    where TEntity : class 
    where TDto : class 
   
{
    protected readonly IGenericRepository<TEntity> GenericRepository;
    protected readonly IMapper Mapper;

    public GenericApplicationService(IGenericRepository<TEntity> genericRepository, IMapper mapper)
    {
        GenericRepository = genericRepository;
        Mapper = mapper;
    }


    public virtual async Task<TDto?> GetByIdAsync(Guid id)
    {
        var entity = await GenericRepository.GetByIdAsync(id);

        return entity != null
            ? Mapper.Map<TEntity, TDto>(entity)
            : null;
    }

    public virtual async Task<List<TDto>> GetAllAsync()
    {
        var list = await GenericRepository.GetAllAsync();
        return Mapper.Map<List<TDto>>(list);
    }

    public virtual async Task<TDto> CreateAsync(TDto dto)
    {
        var entity = Mapper.Map<TDto, TEntity>(dto);
        await GenericRepository.AddAsync(entity);
        return dto;
    }

    public virtual async Task<TDto> UpdateAsync(TDto dto)
    {
        var entity = Mapper.Map<TDto, TEntity>(dto);
        await GenericRepository.UpdateAsync(entity);
        return dto;
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await GenericRepository.DeleteAsync(id);
    }
}