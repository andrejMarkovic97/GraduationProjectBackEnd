namespace ApplicationServices.DataTransferObjects.Session;

public record SessionDto(Guid SessionId, string Address, 
    string City, string Country, string Date, string Time, Guid CourseId);