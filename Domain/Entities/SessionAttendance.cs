namespace Domain.Entities;

public class SessionAttendance
{
    public SessionAttendance(User user, Guid userId, Session session, Guid sessionId)
    {
        User = user;
        UserId = userId;
        Session = session;
        SessionId = sessionId;
    }

    public User User { get; set; }
    public Guid UserId { get; set; }
    public Session Session { get; set; }
    public Guid SessionId { get; set; }
    
}