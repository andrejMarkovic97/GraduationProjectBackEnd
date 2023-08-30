using DataAccess.DbContext;
using DataAccess.GenericRepository;
using Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UserRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
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

    public async Task<List<User>> GetUsersNotAttendingCourse(Guid id)
    {
        var courseId = new SqlParameter("@courseId", id);

        var query = @"
        select distinct t_users.id_user, t_users.email, 
        t_users.first_name, t_users.last_name, t_users.password, t_users.id_role
        from t_users
        left join t_course_attendances on t_users.id_user = t_course_attendances.id_user
        inner join t_roles on t_users.id_role = t_roles.id_role
        where (t_course_attendances.id_course != @courseId or t_course_attendances.id_course is null)
        and t_users.id_role = 0";
        
        var list = await DbContext
            .Users
            .FromSqlRaw(query, courseId)
            .ToListAsync();

        return list;
    }
}