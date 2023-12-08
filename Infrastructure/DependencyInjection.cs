using Application.Abstractions.Authentication;
using Application.OrderItems.GetOrderItemSummary;
using Domain.Abstractions;
using Domain.Businesses;
using Domain.Customers;
using Domain.Dishes;
using Domain.Menus;
using Domain.OrderItems;
using Domain.Orders;
using Domain.Tables;
using Domain.Users;
using Infrastructure.Authentication.Jwt;
using Infrastructure.Authentication.PasswordHandler;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddPersistence(services, configuration);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        AddRepositories(services);
        AddServices(services);

    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IBusinessRepository, BusinessRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IOrderItemSummary, OrderItemSummary>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }
}
