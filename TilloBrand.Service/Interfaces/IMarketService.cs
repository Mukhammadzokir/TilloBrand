using TilloBrand.Service.DTOs.Markets;

namespace TilloBrand.Service.Interfaces;

public interface IMarketService
{
    public Task<bool> RemoveAsync(long id);
    public Task<MarketForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<MarketForResultDto>> GetAllAsync();
    public Task<MarketForResultDto> CreateAsync(MarketForCreationDto dto);
    public Task<MarketForResultDto> UpdateAsync(long id, MarketForUpdateDto dto);

}
