using TilloBrand.Domain.Commons;
using TilloBrand.Domain.Enums;

namespace TilloBrand.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public Roles Role {  get; set; }
    public ICollection<Order> Orders { get; set; }
}
