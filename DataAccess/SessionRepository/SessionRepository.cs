using DataAccess.DbContext;
using DataAccess.GenericRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SessionRepository;

public class SessionRepository : GenericRepository<Session>
{
    public SessionRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<List<Session>> GetListById(Guid id)
    {
        return await DbContext.Sessions
            .Where(s => s.CourseId == id)
            .AsNoTracking()
            .ToListAsync();
    }
}