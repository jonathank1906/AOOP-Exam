using System;
using System.Threading.Tasks;

Task task1 = Task.Run(() => DoWork("Task 1", 2000));
Task task2 = Task.Run(() => DoWork("Task 2", 1000));
Task task3 = Task.Run(() => DoWork("Task 3", 3000));

await Task.WhenAll(task1, task2, task3);

Console.WriteLine("All tasks finished.");

void DoWork(string name, int delay)
{
    Console.WriteLine($"{name} started.");
    Task.Delay(delay).Wait(); // Simulate work
    Console.WriteLine($"{name} finished after {delay} ms.");
}
