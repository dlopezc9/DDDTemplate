using Domain.Users;

namespace Domain.Orders;

public class Order
{
    public OrderId Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public UserId UserId { get; private set; }
}
