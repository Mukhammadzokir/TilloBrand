
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TilloBrand.Data.IRepositories;
using TilloBrand.Domain.Entities;
using TilloBrand.Service.DTOs.Logins;
using TilloBrand.Service.Exceptions;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Service.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration, IRepository<User> userRepository)
    {
        this._userRepository = userRepository;
        this._configuration = configuration;
    }

    public async Task<LoginResultDto> AuthenticateAsync(LoginDto dto)
    {
        var user = await this._userRepository.SelectAll()
            .Where(u => u.Email == dto.Email && u.Password == dto.Password)
            .FirstOrDefaultAsync();
        if(user is null)
            throw new CustomException(400, "Email or password is incorrect");

        return new LoginResultDto
        {
            Token = GenerateToken(user)
        };

    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(this._configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim(ClaimTypes.Role, user.Role.ToString()),
                 new Claim(ClaimTypes.Name, user.FirstName.ToString()),

            }),
            Audience = _configuration["JWT:Audience"],
            Issuer = _configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(this._configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
