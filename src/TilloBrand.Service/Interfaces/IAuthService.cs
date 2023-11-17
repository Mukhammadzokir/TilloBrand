using TilloBrand.Service.DTOs.Logins;

namespace TilloBrand.Service.Interfaces;

public interface IAuthService
{
    public Task<LoginResultDto> AuthenticateAsync(LoginDto dto);
}
