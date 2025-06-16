//using System.Threading;
//using System.Threading.Tasks;

async Task StoppableProcessingLoop(CancellationToken token) 
{
    int itemsProcessed = 0;
    Console.WriteLine("Stoppable loop started.");
    try
    {
        while (true) // Loop indefinitely until cancelled
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Exiting.");
                break; // Exit the loop cleanly
            }

            itemsProcessed++;
            Console.WriteLine($"Processing item {itemsProcessed}...");

            // Simulate work, passing the token to awaitable operations
            await Task.Delay(500, token);

            Console.WriteLine($"Finished item {itemsProcessed}.");
        }
    }
    catch (OperationCanceledException)
    {
        // This exception is expected if Task.Delay (or another cancellable method) is cancelled
        Console.WriteLine("Loop cancelled via OperationCanceledException.");
    }
    finally
    {
        Console.WriteLine($"Stoppable loop finished after processing {itemsProcessed} items.");
    }
}

// --- How to use it ---
var cts = new CancellationTokenSource();

Console.WriteLine("Starting stoppable processing loop...");
Task loopTask = StoppableProcessingLoop(cts.Token);

Console.WriteLine("Running for 3 seconds...");
await Task.Delay(3000);

Console.WriteLine("Requesting cancellation...");
cts.Cancel(); // Signal the loop to stop

await loopTask; // Wait for the loop task to actually finish cleaning up
Console.WriteLine("Loop task completed after cancellation.");
cts.Dispose();