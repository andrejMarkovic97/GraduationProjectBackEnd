namespace Domain.Entities;

public class CourseAttendance
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
}