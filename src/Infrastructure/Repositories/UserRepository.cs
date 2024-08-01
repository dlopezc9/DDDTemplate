using Domain.Orders;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public Task<User?> GetByIdAsync(UserId id)
    {
        return _context.Users
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }
}
