using TilloBrand.Domain.Entities;

namespace TilloBrand.Service.DTOs.Orders;

public class OrderForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long ProductId { get; set; }
}
