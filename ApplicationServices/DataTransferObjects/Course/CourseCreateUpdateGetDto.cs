using ApplicationServices.DataTransferObjects.Category;
using ApplicationServices.DataTransferObjects.TopicDto;
using Microsoft.AspNetCore.Http;

namespace ApplicationServices.DataTransferObjects.Course;

public record CourseCreateUpdateGetDto(Guid? CourseId, string Name,
    string Description, string ImagePath, int NumberOfSessionsForCertificate ,Guid CategoryId, Guid TopicId);
