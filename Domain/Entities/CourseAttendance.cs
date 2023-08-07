namespace Domain.Entities;

public class CourseAttendance
{
    public CourseAttendance(User user, Guid userId, Course course, Guid courseId)
    {
        User = user;
        UserId = userId;
        Course = course;
        CourseId = courseId;
    }

    public User User { get; set; }
    public Guid UserId { get; set; }
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
}