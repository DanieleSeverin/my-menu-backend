using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Customers;
using Domain.Dishes;
using Domain.OrderItems;
using Domain.Tables;
using MediatR;

namespace Application.OrderItems.AddDishToOrder;

internal sealed class AddDishToOrderCommandHandler : ICommandHandler<AddDishToOrderCommand, AddDishToOrderResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDishRepository _dishRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddDishToOrderCommandHandler(ICustomerRepository customerRepository,
                                        IDishRepository dishRepository,
                                        IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _dishRepository = dishRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AddDishToOrderResponse>> Handle(AddDishToOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new CustomerId(request.CustomerId));

        if (customer is null)
        {
            return Result.Failure<AddDishToOrderResponse>(CustomerErrors.NotFound);
        }

        var dish = await _dishRepository.GetByIdAsync(new DishId(request.DishId));

        if (dish is null)
        {
            return Result.Failure<AddDishToOrderResponse>(DishErrors.NotFound);
        }

        var getCurrentOrderResult = customer.GetCurrentOrder();

        if (getCurrentOrderResult.IsFailure)
        {
            return Result.Failure<AddDishToOrderResponse>(getCurrentOrderResult.Error!);
        }

        var currentOrder = getCurrentOrderResult.Value;

        OrderItem orderItem = new OrderItem(
            currentOrder.Id,
            new DishId(request.DishId));

        currentOrder.Add(orderItem);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success(
            new AddDishToOrderResponse(orderItem.Id.Value));
    }
}
