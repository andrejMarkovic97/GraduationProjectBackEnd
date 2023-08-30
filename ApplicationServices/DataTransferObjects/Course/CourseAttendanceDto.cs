namespace ApplicationServices.DataTransferObjects.Course;

public record CourseAttendanceDto(Guid UserId, string FirstName, string LastName,
    int NumberOfSessionsForCertificate, int AttendedSessions, string HasCertificate);