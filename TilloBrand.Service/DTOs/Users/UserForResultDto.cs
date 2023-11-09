using TilloBrand.Domain.Enums;
using TilloBrand.Service.DTOs.Orders;

namespace TilloBrand.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public Roles Role {  get; set; }
    public ICollection<Orders.OrderForResultDto> Orders { get; set; }
}
