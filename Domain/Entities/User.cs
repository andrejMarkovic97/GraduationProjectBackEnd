namespace Domain.Entities;

public class User
{
    #region Entity Properties

    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    
    #endregion

    #region Navigational Properties

    public List<CourseAttendance> CourseAttendances { get; set; }
    public List<SessionAttendance> SessionAttendances { get; set; }
    public Role Role { get; set; }
    public Guid RoleId { get; set; }

    public List<Certificate> Certificates { get; set; }

    #endregion
    
}