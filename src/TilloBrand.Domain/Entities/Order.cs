using TilloBrand.Domain.Commons;

namespace TilloBrand.Domain.Entities;
public class Order : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
}
