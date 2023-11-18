using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Customers;
using Domain.Dishes;
using Domain.Orders;
using Domain.Tables;
using MediatR;

namespace Application.Orders.AddDishToOrder;

internal sealed class AddDishToOrderCommandHandler : ICommandHandler<AddDishToOrderCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDishRepository _dishRepository;
    private readonly ITableRepository _tableRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddDishToOrderCommandHandler(ICustomerRepository customerRepository,
                                        IDishRepository dishRepository,
                                        ITableRepository tableRepository,
                                        IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _dishRepository = dishRepository;
        _tableRepository = tableRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(AddDishToOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new CustomerId(request.CustomerId));

        if(customer is null)
        {
            return Result.Failure<Guid>(CustomerErrors.NotFound);
        }

        var dish = await _dishRepository.GetByIdAsync(new DishId(request.DishId));

        if (dish is null)
        {
            return Result.Failure<Guid>(DishErrors.NotFound);
        }

        var getCurrentOrderResult = customer.GetCurrentOrder();

        if (getCurrentOrderResult.IsFailure)
        {
            return Result.Failure<Guid>(getCurrentOrderResult.Error);
        }

        var currentOrder = getCurrentOrderResult.Value;

        OrderItem orderItem = new OrderItem(
            currentOrder.Id, 
            new DishId(request.DishId));

        currentOrder.Add(orderItem);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success(orderItem.Id.Value);
    }
}
