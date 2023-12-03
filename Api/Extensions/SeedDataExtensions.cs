using Domain.Businesses;
using Domain.Customers;
using Domain.Dishes;
using Domain.Menus;
using Domain.OrderItems;
using Domain.Orders;
using Domain.Shared;
using Domain.Tables;
using Domain.Users;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class SeedDataExtensions
{
    public async static Task SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        bool DataAlreadyPresent = await DbContext.Set<Business>().AnyAsync();

        if(DataAlreadyPresent)
        {
            return;
        }

        User user = User.Create(
            new FirstName("Super"),
            new LastName("Admin"),
            new Email("admin@mymenu.com"),
            new Password("my-password")
            );

        DbContext.Add(user);

        Business business = new Business();
        DbContext.Add(business);

        Table table = new Table(new TableIdentifier("1"), business.Id, numberOfSeats: 1);
        DbContext.Add(table);

        Customer customer = new Customer(business.Id, table.Id);
        DbContext.Add(customer);

        Menu menu = new Menu(business.Id, name: "Test Menu", description: "This is a test menu");
        DbContext.Add(menu);

        Dish dish = new Dish(menu.Id, name: "Test Dish", new Money(9.99m, Currency.Eur));
        DbContext.Add(dish);

        Order order = new Order(customer.Id);
        DbContext.Add(order);

        OrderItem orderItem = new OrderItem(order.Id, dish.Id);
        DbContext.Add(orderItem);

        await DbContext.SaveChangesAsync();
    }
}
