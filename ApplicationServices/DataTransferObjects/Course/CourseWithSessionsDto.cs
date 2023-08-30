using ApplicationServices.DataTransferObjects.Session;

namespace ApplicationServices.DataTransferObjects.Course;

public record CourseWithSessionsDto( string Name, List<SessionDto> Sessions);