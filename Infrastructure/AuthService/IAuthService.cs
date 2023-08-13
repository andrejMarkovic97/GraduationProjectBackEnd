using Infrastructure.AuthToken;
using Infrastructure.LoginDto;

namespace Infrastructure.AuthService;

public interface IAuthService
{
    Task<Token?> Authenticate(LoginUserDto user);
}