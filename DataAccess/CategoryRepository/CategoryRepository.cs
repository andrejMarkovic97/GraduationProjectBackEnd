using DataAccess.DbContext;
using DataAccess.GenericRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CategoryRepository;

public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public override Task<List<Category>> GetAllAsync()
    {
        return DbContext.Categories
            .Include(c => c.Topics)
            .Include(c=> c.Courses)
            .ToListAsync();
    }
}