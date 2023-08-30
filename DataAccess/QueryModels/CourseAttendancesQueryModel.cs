namespace DataAccess.QueryModels;

public class CourseAttendancesQueryModel
{
    public CourseAttendancesQueryModel(string firstName, string lastName, int numberOfSessionsForCertificate, int attendedSessions, bool hasCertificate)
    {
        FirstName = firstName;
        LastName = lastName;
        NumberOfSessionsForCertificate = numberOfSessionsForCertificate;
        AttendedSessions = attendedSessions;
        HasCertificate = hasCertificate;
    }

    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int NumberOfSessionsForCertificate { get; set; }
    public int AttendedSessions { get; set; }
    public bool HasCertificate { get; set; }
    
}