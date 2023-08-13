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
    public Guid RoleId { get; set; } = Guid.Parse("F370835C-E177-4EA8-814B-48C81BAC5D57");

}