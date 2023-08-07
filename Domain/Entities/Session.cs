namespace Domain.Entities;

public class Session
{
    public Session(Guid sessionId, string address, DateTime sessionDate, Course course, Guid courseId, List<SessionAttendance> sessionAttendances)
    {
        SessionId = sessionId;
        Address = address;
        SessionDate = sessionDate;
        Course = course;
        CourseId = courseId;
        SessionAttendances = sessionAttendances;
    }

    public Guid SessionId { get; set; }
    public string Address { get; set; }
    public DateTime SessionDate { get; set; }
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public List<SessionAttendance> SessionAttendances{ get; set; }
}