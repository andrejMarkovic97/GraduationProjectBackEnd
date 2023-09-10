using ApplicationServices.DataTransferObjects.Course;
using Domain.Entities;

namespace ApplicationServices.DataTransferObjects;

public record UserDto(Guid UserId, string Email, string FirstName, string LastName, List<CourseAttendancePostDto> CourseAttendances, RoleDto Role);
