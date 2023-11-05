using Events.Classes;
using System.ComponentModel;

namespace Events.Service;

public class EventApp
{
    Newsletter Newsletter { get; init; }
    public CustomerList<Customer> Customers { get; set; } = new();
    public string Message { get; private set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public EventApp(Newsletter newsletter)
    {  
        Newsletter = newsletter;

        // Subscribe to the AddedEvent in the CustomerList
        Customers.AddedEvent += Added;
    }

    private void Added(object? sender, Customer customer) => Message = $"Added {customer.Name}";
    public void AddCustomer() => Customers.Add(new Customer(Name));

    public void SubscribeToNewsletter(Customer customer)
    {
        customer.IsSubscribed = true;
        Newsletter.Subscribe(customer.ReceiveArticle);
    }
    public void UnsubscribeToNewsletter(Customer customer)
    {
        customer.IsSubscribed = false;
        customer.EventMessage = string.Empty;
        Newsletter.Unsubscribe(customer.ReceiveArticle);
    }

    public void PublishArticle(string content) => Newsletter.Publish(content);

}
