using Application.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Orders;
using Infrastructure.Repositories;
using Domain.Users;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options
            .UseSqlServer(configuration.GetConnectionString("Database"),
            x => x.MigrationsAssembly("Infrastructure")));

        services.AddScoped<IDataContext>(sp =>
            sp.GetRequiredService<DataContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<DataContext>());

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
