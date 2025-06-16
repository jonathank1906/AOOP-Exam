using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int sharedCounter = 0;
    static object counterLock = new object();

    static async Task Main()
    {
        Task task1 = Task.Run(() => {
            for (int i = 0; i < 1000; i++)
            {
                lock (counterLock)
                {
                    sharedCounter++;
                }
            }
        });

        Task task2 = Task.Run(() => {
            for (int i = 0; i < 1000; i++)
            {
                lock (counterLock)
                {
                    sharedCounter++;
                }
            }
        });

        await Task.WhenAll(task1, task2);

        Console.WriteLine($"Final counter value: {sharedCounter}");
    }
}
