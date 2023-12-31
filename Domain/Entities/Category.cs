namespace Domain.Entities;

public class Category
{
    #region Entity Properties
    
    public Guid CategoryId { get; set; } 

    public string CategoryName  { get; set; }
    
    #endregion

    #region Navigational Properties
    
    public List<Course> Courses { get; set; }

    public List<Topic> Topics { get; set; }

    #endregion

    
    
}