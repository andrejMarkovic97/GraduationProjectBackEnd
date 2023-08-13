using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DataAccess.UserRepository;
using Domain.Entities;
using Infrastructure.AuthService;
using Infrastructure.AuthToken;
using Infrastructure.LoginDto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.AuthenticationService;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public AuthService(IConfiguration configuration, IUserRepository userRepository,IMapper mapper)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Token?> Authenticate(LoginUserDto loginUser)
    {
        var user = _mapper.Map<User>(loginUser);
        var response = await _userRepository.Authenticate(user);

        if (!response)
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
}
