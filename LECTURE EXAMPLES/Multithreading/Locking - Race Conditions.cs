using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    private static readonly object _counterLock = new object();

    static async Task Main(string[] args)
    {
        int sharedCounter = 0;
        List<Task> tasks = new List<Task>();

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                for (int j = 0; j < 1000; j++)
                {
                    lock (_counterLock)
                    {
                        sharedCounter++;
                    }
                }
            }));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine($"Final Counter (Safe with lock): {sharedCounter}");
    }
}

/*
This example shows multiple threads accessing the same data
at the same time, in a thread-safe manner using locks.
*/
