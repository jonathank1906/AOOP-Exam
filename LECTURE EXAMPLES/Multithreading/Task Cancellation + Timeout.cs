using System.Threading;
using System.Threading.Tasks;

async Task<string> LongRunningOperation(CancellationToken token)
{
    Console.WriteLine("Long operation started...");
    await Task.Delay(5000, token); // Simulate 5 seconds work
    Console.WriteLine("Long operation finished.");
    return "Operation Result";
}

// --- Using Task.WhenAny for Timeout ---
var cts = new CancellationTokenSource();
Task<string> operationTask = LongRunningOperation(cts.Token);
Task timeoutTask = Task.Delay(TimeSpan.FromSeconds(3), cts.Token); // 3 second timeout

Console.WriteLine("Racing operation against 3-second timeout...");

// Wait for whichever task finishes first
Task completedTask = await Task.WhenAny(operationTask, timeoutTask);

if (completedTask == operationTask)
{
    // Operation finished before timeout
    Console.WriteLine("Operation completed successfully.");
    // We need to await the original task again to safely get the result or propagate exceptions
    string result = await operationTask;
    Console.WriteLine($"Result: {result}");
}
else
{
    // Timeout task finished first
    Console.WriteLine("Operation timed out!");
    // Important: Cancel the original operation if it timed out
    Console.WriteLine("Cancelling long operation...");
    cts.Cancel();
}
cts.Dispose();


/*
Observe the output changes if the timeout on line 15 is changed
from 3 to 6 seconds.
*/