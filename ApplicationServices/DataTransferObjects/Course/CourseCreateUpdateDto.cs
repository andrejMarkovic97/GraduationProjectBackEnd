using Microsoft.AspNetCore.Http;

namespace ApplicationServices.DataTransferObjects.Course;

public record CourseCreateUpdateDto(string Name, string Description, IFormFile ImageFile)
{
    public string Name { get; set; } = Name;
    public string Description { get; set; } = Description;
    public IFormFile Image { get; set; } = ImageFile;
}