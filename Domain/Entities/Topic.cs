namespace Domain.Entities;

public class Topic
{
    #region Entity Properties

    public Guid TopicId { get; set; }
    public string TopicName { get; set; }

    #endregion

    #region Navigational Properties
    
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    
    #endregion
   
}