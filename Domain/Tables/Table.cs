using Domain.Businesses;
using Domain.Customers;
using Domain.Orders;

namespace Domain.Tables;

public class Table
{
    public TableId Id { get; init; }
    public TableIdentifier TableIdentifier { get; init; }
    public BusinessId BusinessId { get; init; }
    public int NumberOfSeats { get; set; }
    public List<Customer> Customers { get; init; }
    public Business Business { get; init; }

    public Table(TableIdentifier tableIdentifier, BusinessId businessId, int numberOfSeats)
    {
        if (numberOfSeats <= 0)
        {
            throw new ArgumentException("Number of seats must be > 0.");
        }

        if (string.IsNullOrWhiteSpace(tableIdentifier.Value))
        {
            throw new ArgumentNullException("Table identifier is required.");
        }

        Id = TableId.New();
        TableIdentifier = tableIdentifier;
        BusinessId = businessId;
        NumberOfSeats = numberOfSeats;
        Customers = new List<Customer>();
    }

    public void AddCustomer(Customer customer)
    {
        Customers.Add(customer);
    }

    public void RemoveCustomer(CustomerId customerId)
    {
        var customer = Customers.FirstOrDefault(x => x.Id.Value == customerId.Value);
        if (customer is not null)
        {
            Customers.Remove(customer);
        }
    }

    public void ClearCustomers()
    {
        Customers.Clear();
    }

    public List<Order> GetOrderList()
    {
        return Customers
            .SelectMany(c => c.Orders)
            .Where(o => o.Sent == false)
            .ToList();
    }
}
