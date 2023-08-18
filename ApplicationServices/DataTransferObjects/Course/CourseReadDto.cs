namespace ApplicationServices.DataTransferObjects.Course;

public record CourseReadDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}