//css_include AccountLoader.cs
using System;
using System.Collections.Generic;

class Program
{
    public List<StudentAccount> StudentAccounts { get; set; } = new();

    static void Main(string[] args)
    {
        Console.WriteLine("Loading student accounts:");
        AccountLoader loader = new();
        var accounts = loader.LoadAccounts();

        foreach (var account in accounts)
        {
            Console.WriteLine(account);
        }
    }
}