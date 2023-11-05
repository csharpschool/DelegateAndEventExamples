namespace Events.Classes;

public class Customer
{
    public string Name { get; init; }
    public Customer(string name) => Name = name;
    public string EventMessage { get; set; } = string.Empty;
    public bool IsSubscribed { get; set; }

    public void ReceiveArticle(object? sender, Article article) =>
        EventMessage = $"{Name}: {article}";
}
