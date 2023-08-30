using ApplicationServices.DataTransferObjects.Category;
using ApplicationServices.DataTransferObjects.TopicDto;

namespace ApplicationServices.DataTransferObjects.Course;

public record CourseReadDto(Guid CourseId,string Name, string Description, string ImagePath, Guid TopicId, Guid CategoryId);
