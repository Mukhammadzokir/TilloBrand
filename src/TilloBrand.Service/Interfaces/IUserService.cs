using TilloBrand.Service.Configurations;
using TilloBrand.Service.DTOs.Users;

namespace TilloBrand.Service.Interfaces;

public interface IRepository
{
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> GetAllAsync(PaginationParams @params);
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    public Task<UserForResultDto> UpdateAsync(long id, UserForUpdateDto dto);
}
