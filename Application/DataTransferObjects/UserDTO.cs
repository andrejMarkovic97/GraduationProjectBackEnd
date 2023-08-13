namespace Application.DataTransferObjects;

public record UserDto(Guid UserId, string Email, string Password, string FirstName, string LastName)
{
    public Guid UserId { get; set; } = UserId;
    public string Email { get; set; } = Email;
    public string Password { get; set; } = Password;
    public string FirstName { get; set; } = FirstName;
    public string LastName { get; set; } = LastName;
}