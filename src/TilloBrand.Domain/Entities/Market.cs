using TilloBrand.Domain.Commons;

namespace TilloBrand.Domain.Entities;

public class Market : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
}
