using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Customers;
using Domain.Orders;

namespace Application.Orders.CancelOrder;

internal sealed class CancelOrderCommandHandler : ICommandHandler<CancelOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelOrderCommandHandler(IOrderRepository orderRepository,
                                   IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(new OrderId(request.OrderId), cancellationToken);

        if(order is null)
        {
            return Result.Failure(OrderErrors.NotFound);
        }

        order.Cancel();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
