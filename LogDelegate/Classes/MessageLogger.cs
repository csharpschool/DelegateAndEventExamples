using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System.Diagnostics;

namespace LogDelegate.Classes;

public class MessageLogger
{
    private readonly ILocalStorageService localStorage;

    public IJSRuntime JSRuntime { get; }

    public MessageLogger(ILocalStorageService LocalStorage, IJSRuntime jsRuntime)
    {
        localStorage = LocalStorage;
        JSRuntime = jsRuntime;
    }

    public async Task<string> LogToLocalStorage(string message)
    {
        // Save the data object to local storage directly
        await localStorage.SetItemAsync("Message", message);
        return $"Saved '{message}' to the browser's LocalStorage.";
    }

    public async Task<string> LogToScreen(string message)
    {
        // Do something
        await Task.Delay(500);
        return $"Logged: '{message}'.";
    }

    public async Task<string> LogToOutput(string message)
    {
        // Write to Visual Studio's Output window
        await JSRuntime.InvokeVoidAsync("console.log", message);
        return $"Logged: '{message}' to output.";
    }


}
