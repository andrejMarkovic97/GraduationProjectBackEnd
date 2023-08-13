using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DataAccess.GenericRepository;
using DataAccess.UserRepository;
using Domain.Entities;
using Infrastructure.AuthModels;
using Infrastructure.AuthToken;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.AuthService;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Role> _roleRepository;


    public AuthService(IConfiguration configuration, IUserRepository userRepository,IMapper mapper, IGenericRepository<Role> roleRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<Token?> Authenticate(LoginUserDto loginUser)
    {
        var user = _mapper.Map<User>(loginUser);
        var existingUser = await _userRepository.GetUserByEmail(user.Email);
        var passwordHasher = new PasswordHasher<User>();
        if (existingUser==null || 
            passwordHasher.VerifyHashedPassword(user,existingUser.Password,user.Password) == PasswordVerificationResult.Failed)
        {
            return null;
        }
        // User name and password are valid. 
        // Generate JSON Web Token

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Token { AuthToken = tokenHandler.WriteToken(token) };
    }

    public async Task<AuthResult> Register(RegisterUserDto registerUser)
    {
        var authResult = new AuthResult{Success = true};
        var user = _mapper.Map<User>(registerUser);
        var existingUser = await _userRepository.GetUserByEmail(user.Email);

        if (existingUser != null)
        {
            authResult.Success = false;
            authResult.ErrorMessage = "A user with this email already exists";
            return authResult;
        }
        var passwordHasher = new PasswordHasher<User>();
        user.Password = passwordHasher.HashPassword(user, user.Password);
        
        await _userRepository.AddAsync(user);

        return authResult;
    }
    
}
