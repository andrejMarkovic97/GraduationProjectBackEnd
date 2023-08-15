using DataAccess.DbContext;
using DataAccess.GenericRepository;
using Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UserRepository;

public class UserRepository : GenericRepository<User>,IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<List<User>> GetAllAsync()
    {
        return await DbContext.Users
            .Include(u => u.Certificates)
            .Include(u => u.Role)
            .Include(u => u.SessionAttendances)
            .Include(u => u.CourseAttendances)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<User?> GetByIdAsync(Guid id)
    {
        return await DbContext.Users
            .Include(u => u.Certificates)
            .Include(u => u.Role)
            .Include(u => u.SessionAttendances)
            .Include(u => u.CourseAttendances)
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var existingUser = await DbContext.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == email);

        return existingUser;
    }

    
}