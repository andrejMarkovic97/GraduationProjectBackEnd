
namespace Domain.Entities;

public class Course
{
    public Course(Guid courseId, string name,
        string description, List<Session> sessions,
        List<CourseAttendance> courseAttendances, List<Certificate> certificates,
        Category category)
    {
        CourseId = courseId;
        Name = name;
        Description = description;
        Sessions = sessions;
        CourseAttendances = courseAttendances;
        Certificates = certificates;
        Category = category;
    }

    #region Entity Properties
    
    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    #endregion
    
    #region Navigational Properties
    
    public List<Session> Sessions { get; set; }
    public List<CourseAttendance> CourseAttendances { get; set; }
    public List<Certificate> Certificates { get; set; }
    public Category Category { get; set; }
    
    #endregion
    
}