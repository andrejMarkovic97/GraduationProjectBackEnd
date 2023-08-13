using DataAccess.DbContext;
using DataAccess.GenericRepository;
using Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UserRepository;

public class UserRepository : GenericRepository<User>,IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<List<User>> GetAllAsync()
    {
        return await DbContext.Users
            .Include(u => u.Certificates)
            .Include(u => u.Role)
            .Include(u => u.SessionAttendances)
            .Include(u => u.CourseAttendances)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<User?> GetByIdAsync(Guid id)
    {
        return await DbContext.Users
            .Include(u => u.Certificates)
            .Include(u => u.Role)
            .Include(u => u.SessionAttendances)
            .Include(u => u.CourseAttendances)
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<bool> Authenticate(User user)
    {
        var existingUser = await DbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
        
        return existingUser is not null && VerifyPassword(existingUser.Password, user.Password);
    }

    private bool VerifyPassword(string existingUserPassword, string userInputPassword)
    {
        // Split the stored password into salt and hashed value
        var parts = existingUserPassword.Split('.', 2);
        if (parts.Length != 2)
        {
            return false;
        }

        var salt = Convert.FromBase64String(parts[0]);
        var storedHashedPassword = parts[1];

        // Hash the user input password with the stored salt
        var hashedInputPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: userInputPassword,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        // Compare the stored hashed value with the newly generated hashed input password
        return storedHashedPassword == hashedInputPassword;
    }
}