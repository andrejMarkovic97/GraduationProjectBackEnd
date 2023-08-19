using ApplicationServices.DataTransferObjects.TopicDto;

namespace ApplicationServices.DataTransferObjects.Category;

public record CategoryReadDto(Guid CategoryId, string CategoryName, List<TopicReadDto> Topics);
