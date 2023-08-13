namespace Infrastructure.LoginDto;

public record LoginUserDto(string Email, string Password)
{
    public string Email { get; set; } = Email;
    public string Password { get; set; } = Password;
}