using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What would you like to sort?");
        Console.WriteLine("1. Numbers");
        Console.WriteLine("2. Strings");
        Console.WriteLine("3. Characters");
        Console.Write("Enter your choice (1, 2, or 3): ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                SortNumbers();
                break;
            case "2":
                SortStrings();
                break;
            case "3":
                SortChars();
                break;
            default:
                Console.WriteLine("Invalid choice. Please run the program again.");
                break;
        }
    }
    
    static void SortNumbers()
    {
        List<int> numbers = new List<int> { 5, 3, 8, 1, 2, 7, 4, 6 };
        
        Console.WriteLine("\nOriginal numbers:");
        PrintList(numbers);
        
        BubbleSort(numbers);
        
        Console.WriteLine("\nSorted numbers:");
        PrintList(numbers);
    }
    
    static void SortStrings()
    {
        List<string> words = new List<string> { "banana", "apple", "pear", "orange", "grape" };
        
        Console.WriteLine("\nOriginal strings:");
        PrintList(words);
        
        BubbleSortStrings(words);
        
        Console.WriteLine("\nSorted strings:");
        PrintList(words);
    }
    
    static void SortChars()
    {
        List<char> characters = new List<char> { 'z', 'a', 'm', 'b', 'k', 'd' };
        
        Console.WriteLine("\nOriginal characters:");
        PrintList(characters);
        
        BubbleSortChars(characters);
        
        Console.WriteLine("\nSorted characters:");
        PrintList(characters);
    }
    
    // Original number bubble sort (unchanged)
    static void BubbleSort(List<int> list)
    {
        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                    swapped = true;
                }
            }
            
            if (!swapped)
                break;
        }
    }
    
    // String bubble sort
    static void BubbleSortStrings(List<string> list)
    {
        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            
            for (int j = 0; j < n - i - 1; j++)
            {
                if (string.Compare(list[j], list[j + 1]) > 0)
                {
                    string temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                    swapped = true;
                }
            }
            
            if (!swapped)
                break;
        }
    }
    
    // New character bubble sort
    static void BubbleSortChars(List<char> list)
    {
        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    char temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                    swapped = true;
                }
            }
            
            if (!swapped)
                break;
        }
    }
    
    // Generic print method that works for all types
    static void PrintList<T>(List<T> list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}