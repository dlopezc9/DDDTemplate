using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IDataContext
{
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
