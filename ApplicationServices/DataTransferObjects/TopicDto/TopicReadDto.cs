namespace ApplicationServices.DataTransferObjects.TopicDto;

public record TopicReadDto(Guid TopicId,string TopicName)
{
    public Guid TopicId { get; set; } = TopicId;
    public string TopicName { get; set; } = TopicName;
}