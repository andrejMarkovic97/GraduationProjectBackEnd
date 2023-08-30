using DataAccess.DbContext;
using DataAccess.GenericRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CourseRepository;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<List<Course>> GetAllAsync()
    {
        // return await DbContext.Courses
        //     .Include(c => c.Sessions)
        //     .Include(c => c.CourseAttendances)
        //     .Include(c => c.Certificates)
        //     .Include(c => c.Category)
        //     .Include(c => c.Topic)
        //     .ToListAsync();

        return await DbContext.Courses.ToListAsync();
    }
    
}