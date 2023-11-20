using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Orders;

namespace Application.Orders.MarkOrderItemsAsDelivered;

internal sealed class MarkOrderItemsAsDeliveredCommandHandler : ICommandHandler<MarkOrderItemsAsDeliveredCommand>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private IUnitOfWork _unitOfWork;

    public MarkOrderItemsAsDeliveredCommandHandler(IOrderItemRepository orderItemRepository,
                                                  IUnitOfWork unitOfWork)
    {
        _orderItemRepository = orderItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(MarkOrderItemsAsDeliveredCommand request, CancellationToken cancellationToken)
    {
        //TODO: check if Prepared
        OrderItem? orderItem = await _orderItemRepository.GetByIdAsync(
            new OrderItemId(request.OrderItemId),
            cancellationToken);

        if (orderItem is null)
        {
            return Result.Failure(OrderItemErrors.NotFound);
        }

        orderItem.Delivered();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
