using Infrastructure.AuthModels;
using Infrastructure.AuthToken;

namespace Infrastructure.AuthService;

public interface IAuthService
{
    Task<Token?> Authenticate(LoginUserDto user);

    Task<AuthResult> Register(RegisterUserDto user);
}