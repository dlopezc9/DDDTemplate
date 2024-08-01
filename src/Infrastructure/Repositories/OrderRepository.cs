using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }

    public Task<Order?> GetByIdAsync(OrderId id)
    {
        return _context.Orders.SingleOrDefaultAsync(x => x.Id == id);
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }
}
