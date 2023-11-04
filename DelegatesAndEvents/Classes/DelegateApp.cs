using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DelegatesAndEvents.Classes;

public class DelegateApp
{
    public string? Message { get; private set; }
    readonly List<Person> persons = new();

    public async Task Add(Person? person, Delegates.MessageEventCallback messageMethod)
    {
        if (person is not null)
        {
            persons.Add(new(person.Name));
            Message = await messageMethod($"Added {person.Name}"); // Calls the event delgate method
        }
        else
            Message = await messageMethod("Couldn't add the person."); // Calls the event delgate method
    }

    public async Task Remove(string name, Delegates.MessageEventCallback messageMethod)
    {
        var person = persons.SingleOrDefault(p => p.Name == name);
        if(person is not null)
        {
            Message = await messageMethod($"Removed {person.Name}"); // Calls the event delgate method
            persons.Remove(person);
        }
        else
            Message = await messageMethod("Couldn't remove the person."); // Calls the event delgate method
    }
}
