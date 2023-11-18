using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Businesses;
using Domain.Customers;
using Domain.Tables;

namespace Application.Customers.ConnectCustomer;

internal sealed class ConnectCustomerCommandHandler : ICommandHandler<ConnectCustomerCommand, ConnectCustomerResponse>
{
    private readonly IBusinessRepository _businessRepository;
    private readonly ITableRepository _tableRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ConnectCustomerCommandHandler(IBusinessRepository businessRepository,
                                         ITableRepository tableRepository,
                                         ICustomerRepository customerRepository,
                                         IUnitOfWork unitOfWork)
    {
        _businessRepository = businessRepository;
        _tableRepository = tableRepository;
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ConnectCustomerResponse>> Handle(ConnectCustomerCommand request, CancellationToken cancellationToken)
    {
        // Check if Business exists
        var business = await _businessRepository.GetByIdAsync(new BusinessId(request.BusinessId));

        if(business is null)
        {
            return Result.Failure<ConnectCustomerResponse>(BusinessErrors.NotFound);
        }

        // Check if the Table is linked to the Business
        var connectedTable = business.GetTableById(new TableId(request.TableId));
        if (connectedTable is null)
        {
            return Result.Failure<ConnectCustomerResponse>(BusinessErrors.TableNotFound);
        }

        // Check that the Table exists
        var table = await _tableRepository.GetByIdAsync(new TableId(request.TableId));

        if (table is null)
        {
            return Result.Failure<ConnectCustomerResponse>(TableErrors.NotFound);
        }

        // Create Customer
        Customer customer = new Customer(
            new BusinessId(request.BusinessId), 
            new TableId(request.TableId));

        // Save Customer
        _customerRepository.Add(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ConnectCustomerResponse(customer.Id.Value);
    }
}
