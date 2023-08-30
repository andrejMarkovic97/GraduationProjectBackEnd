using DataAccess.DbContext;
using DataAccess.QueryModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CourseAttendancesQueryRepository;

public class CourseAttendancesQueryRepository : ICourseAttendancesQueryRepository
{
    private readonly AppDbContext _dbContext;

    public CourseAttendancesQueryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CourseAttendancesQueryModel>> GetCourseAttendances(Guid id)
    {
        var courseId = new SqlParameter("@courseId", id);
        var query = @"
        SELECT
            t_users.id_user as UserId,
            t_users.first_name AS FirstName,
            t_users.last_name AS LastName, 
            course.num_of_sessions_for_certificate AS NumberOfSessionsForCertificate,
            CAST(
                CASE
                    WHEN t_certificates.id_user IS NOT NULL THEN 1
                    ELSE 0
                END AS BIT
            ) AS HasCertificate,
            (SELECT COUNT(*) 
                FROM t_session_attendances 
                INNER JOIN t_sessions ON t_session_attendances.id_session = t_sessions.id_session
                AND t_sessions.id_course = course.id_course
                WHERE t_session_attendances.id_user = t_users.id_user
                AND t_sessions.id_course = course.id_course) AS AttendedSessions
        FROM t_courses course
        INNER JOIN t_course_attendances ON course.id_course = t_course_attendances.id_course
        INNER JOIN t_users ON t_users.id_user = t_course_attendances.id_user
        LEFT JOIN t_certificates ON t_certificates.id_user = t_users.id_user
        AND t_certificates.id_course = course.id_course
        WHERE course.id_course = @courseId";

        var results = await _dbContext
            .CourseAttendancesQueryModels
            .FromSqlRaw(query, courseId)
            .ToListAsync();

        return results;
    }
}