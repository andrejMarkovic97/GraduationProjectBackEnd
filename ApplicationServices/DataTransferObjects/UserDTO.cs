namespace ApplicationServices.DataTransferObjects;

public record UserDto(Guid UserId, string Email, string FirstName, string LastName);
