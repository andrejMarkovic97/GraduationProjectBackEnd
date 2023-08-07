namespace Domain.Entities;

public class Topic
{
    public Topic(Guid topicId, string topicName, Category category, Guid categoryId)
    {
        TopicId = topicId;
        TopicName = topicName;
        Category = category;
        CategoryId = categoryId;
    }

    #region Entity Properties

    public Guid TopicId { get; set; }
    public string TopicName { get; set; }

    #endregion

    #region Navigational Properties
    
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    
    #endregion
   
}