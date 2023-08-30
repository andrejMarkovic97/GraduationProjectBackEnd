using ApplicationServices.DataTransferObjects.Category;
using ApplicationServices.DataTransferObjects.TopicDto;
using Microsoft.AspNetCore.Http;

namespace ApplicationServices.DataTransferObjects.Course;

public record CourseCreateUpdatePostDto(Guid? CourseId, string Name,
    string Description, int NumberOfSessionsForCertificate , IFormFile Image,
    Guid TopicId, Guid CategoryId);
