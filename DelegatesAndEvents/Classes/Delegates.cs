namespace DelegatesAndEvents.Classes;

public static class Delegates
{
    public delegate Task<string> MessageEventCallback(string message);
    public static async Task<string> AddedEvent(string message)
    {
        // Simulate some post-processing
        await Task.Delay(500);
        return message;
    }

    public static async Task<string> RemovedEvent(string message)
    {
        // Simulate some post-processing
        await Task.Delay(500);
        return message;
    }

}
