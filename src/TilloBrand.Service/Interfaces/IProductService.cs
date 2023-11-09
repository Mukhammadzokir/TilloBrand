using TilloBrand.Service.DTOs.Products;

namespace TilloBrand.Service.Interfaces;

public interface IProductService
{
    public Task<bool> RemoveAsync(long id);
    public Task<ProductForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<ProductForResultDto>> GetAllAsync();
    public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
    public Task<ProductForResultDto> UpdateAsync(long id, ProductForUpdateDto dto);

}
