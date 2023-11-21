using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.OrderItems;
using Domain.Orders;

namespace Application.OrderItems.MarkOrderItemsAsPrepared;

internal sealed class MarkOrderItemsAsPreparedCommandHandler : ICommandHandler<MarkOrderItemsAsPreparedCommand>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private IUnitOfWork _unitOfWork;

    public MarkOrderItemsAsPreparedCommandHandler(IOrderItemRepository orderItemRepository,
                                                  IUnitOfWork unitOfWork)
    {
        _orderItemRepository = orderItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(MarkOrderItemsAsPreparedCommand request, CancellationToken cancellationToken)
    {
        OrderItem? orderItem = await _orderItemRepository.GetByIdAsync(
            new OrderItemId(request.OrderItemId),
            cancellationToken);

        if (orderItem is null)
        {
            return Result.Failure(OrderItemErrors.NotFound);
        }

        orderItem.Prepared();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
