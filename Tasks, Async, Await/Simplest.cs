using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Fetching weather data...");
        string weather = await GetWeatherAsync();
        Console.WriteLine($"Weather data received: {weather}");
    }

    static async Task<string> GetWeatherAsync()
    {
        // Simulate a delay as if calling an external API
        await Task.Delay(2000); // 2 seconds delay
        return "Sunny, 25°C";
    }
}
