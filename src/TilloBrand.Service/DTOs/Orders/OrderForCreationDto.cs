using TilloBrand.Domain.Entities;

namespace TilloBrand.Service.DTOs.Orders;

public class OrderForCreationDto
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
}
