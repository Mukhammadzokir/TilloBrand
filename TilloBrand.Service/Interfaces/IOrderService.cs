using TilloBrand.Service.DTOs.Orders;

namespace TilloBrand.Service.Interfaces;

public interface IOrderService
{
    public Task<bool> RemoveAsync(long id);
    public Task<OrderForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<OrderForResultDto>> GetAllAsync();
    public Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto);
    public Task<OrderForResultDto> UpdateAsync(long id, OrderForUpdateDto dto);

}
