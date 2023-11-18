using Application.Abstractions.Messaging;

namespace Application.Customers.ConnectCustomer;

public record ConnectCustomerCommand(Guid BusinessId, Guid TableId) : ICommand<ConnectCustomerResponse>;
