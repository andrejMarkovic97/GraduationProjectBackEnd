namespace Domain.Entities;

public class SessionAttendance
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Session Session { get; set; }
    public Guid SessionId { get; set; }
    
}