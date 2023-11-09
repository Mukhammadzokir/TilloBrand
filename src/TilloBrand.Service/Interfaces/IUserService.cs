using TilloBrand.Service.DTOs.Users;

namespace TilloBrand.Service.Interfaces;

public interface IUserService
{
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> GetAllAsync();
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    public Task<UserForResultDto> UpdateAsync(long id, UserForUpdateDto dto);
}
