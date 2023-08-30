namespace ApplicationServices.DataTransferObjects.SessionAttendance;

public record SessionAttendanceDto(Guid UserId, string? FirstName, string? LastName);