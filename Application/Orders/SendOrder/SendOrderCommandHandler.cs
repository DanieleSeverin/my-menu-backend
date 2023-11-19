using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Customers;
using Domain.Orders;

namespace Application.Orders.SendOrder;

internal sealed class SendOrderCommandHandler : ICommandHandler<SendOrderCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SendOrderCommandHandler(ICustomerRepository customerRepository,
                                   IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(SendOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new CustomerId(request.CustomerId));

        if (customer is null)
        {
            return Result.Failure(CustomerErrors.NotFound);
        }

        var sendOrderResult = customer.SendOrder();

        if(sendOrderResult.IsFailure)
        {
            return sendOrderResult;
        }

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
