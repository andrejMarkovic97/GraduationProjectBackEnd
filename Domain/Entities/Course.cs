
namespace Domain.Entities;

public class Course
{
    #region Entity Properties
    
    public Guid CourseId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    
    
    #endregion
    
    #region Navigational Properties
    
    public List<Session> Sessions { get; set; }
    public List<CourseAttendance> CourseAttendances { get; set; }
    public List<Certificate> Certificates { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }

    public Topic Topic { get; set; }
    public Guid TopicId { get; set; }
    
    #endregion
    
}