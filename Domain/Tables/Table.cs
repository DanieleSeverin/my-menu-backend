using Domain.Customers;
using Domain.Orders;

namespace Domain.Tables;

public class Table
{
    public Guid Id { get; init; }
    public int NumberOfSeats { get; set; }
    public List<Customer> Customers { get; init; }

    public Table(int numberOfSeats)
    {
        if (numberOfSeats <= 0)
        {
            throw new Exception("Number of seats must be > 0.");
        }

        Id = Guid.NewGuid();
        NumberOfSeats = numberOfSeats;
        Customers = new List<Customer>();
    }

    public void AddCustomer(Customer customer)
    {
        Customers.Add(customer);
    }

    public void RemoveCustomer(Guid customerId)
    {
        var customer = Customers.FirstOrDefault(x => x.Id == customerId);
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
        return Customers.SelectMany(c => c.OrdersSent).ToList();
    }
}
