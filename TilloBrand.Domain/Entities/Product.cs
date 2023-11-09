using TilloBrand.Domain.Commons;

namespace TilloBrand.Domain.Entities;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long MarketId { get; set; }
    public Market Market { get; set; }
    public string Image {  get; set; }
    public decimal Price { get; set; }
}
