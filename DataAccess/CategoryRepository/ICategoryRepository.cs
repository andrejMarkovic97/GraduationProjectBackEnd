using DataAccess.GenericRepository;

namespace DataAccess.CategoryRepository;

public interface ICategoryRepository : IGenericRepository<Domain.Entities.Category>
{
    
}