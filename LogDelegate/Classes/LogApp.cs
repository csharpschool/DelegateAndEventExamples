using Blazored.LocalStorage;
using Microsoft.JSInterop;

namespace LogDelegate.Classes
{
    public class LogApp
    {
        public string? Message { get; private set; }
        public MessageLogger Logger { get; }
        

        public delegate Task<string> LogDelegate(string message);

        public LogApp(MessageLogger logger)
        {
            Logger = logger;
        }

        public async Task Log(string message, LogDelegate logMethod)
        {
            Message = await logMethod(message); // Calls the event delgate method
        }
    }
}
