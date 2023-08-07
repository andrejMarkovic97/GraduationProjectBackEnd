namespace Domain.Entities;

public class Category
{
    public Category(Guid categoryId, string categoryName, List<Course> courses, List<Topic> topics)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
        Courses = courses;
        Topics = topics;
    }

    #region Entity Properties
    
    public Guid CategoryId { get; set; } 

    public string CategoryName  { get; set; }
    
    #endregion

    #region Navigational Properties
    
    public List<Course> Courses { get; set; }

    public List<Topic> Topics { get; set; }

    #endregion

    
    
}