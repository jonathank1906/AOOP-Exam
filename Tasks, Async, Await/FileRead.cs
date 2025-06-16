using System;
using System.IO;
using System.Threading.Tasks;

var chars = await PrintFileAsync("test.txt");
Console.WriteLine($"Number of characters in file: {chars}");

static async Task<int> PrintFileAsync(string name)
{
    using var f = new StreamReader(new FileStream(name,
        FileMode.Open, FileAccess.Read,
        FileShare.Read, 4096, true));

    var buffer = new char[4096];
    int totalChars = 0;
    while (true)
    {
        int charsRead = await f.ReadAsync(buffer);

        if (charsRead == 0)
        {
            break;
        }

        Console.Write(new string(buffer, 0, charsRead));

        totalChars += charsRead;
    }

    Console.WriteLine();
    return totalChars;
}


// This program asynchronously reads a text file and prints it, then
// returns number of characters in that file.
// It purposefully doesn’t use high level I/O operations
// like File.ReadAllText or similar.