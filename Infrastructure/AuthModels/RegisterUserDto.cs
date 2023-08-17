namespace Infrastructure.AuthModels;

public class RegisterUserDto
{
    public RegisterUserDto(string email, string password, string firstName, string lastName)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }

    public int RoleId { get; set; }

}