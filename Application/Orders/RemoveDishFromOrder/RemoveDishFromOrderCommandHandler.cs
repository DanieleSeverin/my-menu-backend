using Application.Abstractions.Messaging;
using Application.Orders.AddDishToOrder;
using Domain.Abstractions;
using Domain.Customers;
using Domain.Dishes;
using Domain.Orders;
using Domain.Tables;

namespace Application.Orders.RemoveDishFromOrder;

internal sealed class RemoveDishFromOrderCommandHandler : ICommandHandler<RemoveDishFromOrderCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveDishFromOrderCommandHandler(ICustomerRepository customerRepository,
                                            IOrderItemRepository orderItemRepository,
                                            IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _orderItemRepository = orderItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveDishFromOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new CustomerId(request.CustomerId));

        if (customer is null)
        {
            return Result.Failure(CustomerErrors.NotFound);
        }

        var getCurrentOrderResult = customer.GetCurrentOrder();

        if (getCurrentOrderResult.IsFailure)
        {
            return Result.Failure(getCurrentOrderResult.Error);
        }

        var currentOrder = getCurrentOrderResult.Value;

        var orderItem = currentOrder.FindOrderItem(new OrderItemId(request.OrderItemId));

        if (orderItem is null)
        {
            return Result.Failure(OrderItemErrors.NotFound);
        }

        _orderItemRepository.Remove(orderItem);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
