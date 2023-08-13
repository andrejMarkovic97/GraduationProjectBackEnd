using AutoMapper;
using DataAccess.GenericRepository;

namespace Application.GenericService;

public class GenericService<TEntityDto, TEntity> : IGenericService<TEntityDto, TEntity>
    where TEntityDto : class
    where TEntity : class
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TEntityDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<TEntityDto>>(entities);
    }

    public async Task<TEntityDto> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TEntityDto>(entity);
    }

    public async Task<TEntityDto> CreateAsync(TEntityDto entityDto)
    {
        var entity = _mapper.Map<TEntity>(entityDto);
        await _repository.AddAsync(entity);
        return _mapper.Map<TEntityDto>(entity);
    }

    public async Task UpdateAsync(TEntityDto entityDto)
    {
        var entity = _mapper.Map<TEntity>(entityDto);
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
