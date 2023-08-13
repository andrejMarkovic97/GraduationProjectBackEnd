namespace Domain.Entities;

public class Session
{
    public Guid SessionId { get; set; }
    public string Address { get; set; }
    public DateTime SessionDate { get; set; }
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public List<SessionAttendance> SessionAttendances{ get; set; }
}