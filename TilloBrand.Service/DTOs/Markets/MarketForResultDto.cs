using TilloBrand.Service.DTOs.Products;

namespace TilloBrand.Service.DTOs.Markets;

public class MarketForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ProductForResultDto> Products { get; set; }
}
