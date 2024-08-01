using Application.Data;
using Domain.Orders;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DataContext : DbContext, IUnitOfWork, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}
