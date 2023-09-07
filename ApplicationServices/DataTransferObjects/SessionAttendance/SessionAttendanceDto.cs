namespace ApplicationServices.DataTransferObjects.SessionAttendance;

public record SessionAttendanceDto(Guid SessionId, Guid UserId, string? FirstName, string? LastName);