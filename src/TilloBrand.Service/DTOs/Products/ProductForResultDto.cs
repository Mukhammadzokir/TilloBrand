using TilloBrand.Domain.Entities;

namespace TilloBrand.Service.DTOs.Products;

public class ProductForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long MarketId { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
}
