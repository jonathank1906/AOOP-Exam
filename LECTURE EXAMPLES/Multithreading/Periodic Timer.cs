using System.Threading;
using System.Threading.Tasks;

// Assume token comes from a CancellationTokenSource (See previous slide!)
async Task RunPeriodicWork(CancellationToken token)
{
    // Create timer for a 5-second interval
    using var timer = new PeriodicTimer(TimeSpan.FromSeconds(2));

    try
    {
        // Loop continues as long as timer ticks and cancellation isn't requested
        while (await timer.WaitForNextTickAsync(token)) // Pass token here!
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Doing periodic work...");
            // Perform your async or sync work here
            // await SomeAsyncWork(token);
        }
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Periodic work cancelled."); // Expected when token is cancelled
    }
    finally
    {
        Console.WriteLine("Periodic work loop finished.");
    }
}

// To start:
var cts = new CancellationTokenSource();
Task workTask = RunPeriodicWork(cts.Token);
// To stop:
Task.Delay(10000).Wait(); 
cts.Cancel();