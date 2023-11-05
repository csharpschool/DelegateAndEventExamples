namespace Events.Classes;

public class CustomerList<Customer> : List<Customer>
{
    public event EventHandler<Customer>? AddedEvent;

    public new void Add(Customer customer)
    {
		try
		{
			base.Add(customer);
			// Check that at least one method is added to the AddedEvent
			if (AddedEvent is not null) AddedEvent(this, customer);
		}
		catch
		{
			throw;
		}
    }
}
