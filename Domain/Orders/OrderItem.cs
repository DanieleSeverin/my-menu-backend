﻿using Domain.Dishes;

namespace Domain.Orders;

public class OrderItem
{
    public OrderItemId Id { get; init; }
    public DishId DishId { get; init; }
    public OrderId OrderId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? PreparedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }

    public OrderItem(OrderId orderId, DishId dishId)
    {
        Id = OrderItemId.New();
        OrderId = orderId;
        DishId = dishId;
        CreatedAt = DateTime.Now;
    }

    public void Prepared()
    {
        PreparedAt = DateTime.Now;
    }

    public void Delivered()
    {
        DeliveredAt = DateTime.Now;
    }
}
