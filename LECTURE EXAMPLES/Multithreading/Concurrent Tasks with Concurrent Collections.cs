using System.Collections.Concurrent;
using System.Threading.Tasks;

// Shared dictionary to store word counts
ConcurrentDictionary<string, int> wordCounts = new ConcurrentDictionary<string, int>();

// Simulate processing data sources in parallel
Task task1 = Task.Run(() => CountWords(new[] { "apple", "banana", "apple" }));
Task task2 = Task.Run(() => CountWords(new[] { "orange", "banana", "orange" }));
Task task3 = Task.Run(() => CountWords(new[] { "apple", "orange", "grape" }));

await Task.WhenAll(task1, task2, task3);

Console.WriteLine("Word Counts (ConcurrentDictionary):");
foreach (var kvp in wordCounts.OrderBy(kv => kv.Key))
{
    Console.Write($" | {kvp.Key}: {kvp.Value}");
}
Console.Write(" |");

// Helper method simulating processing words from a source
void CountWords(IEnumerable<string> words)
{
    foreach (string word in words)
    {
        // AddOrUpdate handles the logic:
        // - If new, add it with value 1.
        // - If exists, call the lambda to increment the current value.
        wordCounts.AddOrUpdate(word, 1, (key, currentCount) => currentCount + 1);
        Task.Delay(10).Wait();
    }
}