using Microsoft.AspNetCore.Http;
using TilloBrand.Domain.Entities;

namespace TilloBrand.Service.DTOs.Products;

public class ProductForUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long MarketId { get; set; }
    public IFormFile Image { get; set; }
    public decimal Price { get; set; }
}
