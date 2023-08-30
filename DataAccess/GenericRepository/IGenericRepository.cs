namespace DataAccess.GenericRepository;

public interface IGenericRepository<T> where T: class
{
    Task<List<T>> GetAllAsync();

    Task<List<T>> GetListById(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);

    Task AddList(List<T> list);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}