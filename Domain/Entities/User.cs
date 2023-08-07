namespace Domain.Entities;

public class User
{
    public User(Guid userId, string email,
        string password, string firstName,
        string lastName, List<CourseAttendance> courseAttendances,
        List<SessionAttendance> sessionAttendances, Role role,
        Guid roleId)
    {
        UserId = userId;
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        CourseAttendances = courseAttendances;
        SessionAttendances = sessionAttendances;
        Role = role;
        RoleId = roleId;
    }

    #region Entity Properties
    
    public Guid UserId { get; set; }
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

    #endregion
    
}