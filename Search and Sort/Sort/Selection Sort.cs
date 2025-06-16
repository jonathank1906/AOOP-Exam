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
        
        SelectionSort(numbers);
        
        Console.WriteLine("\nSorted numbers:");
        PrintList(numbers);
    }
    
    static void SortStrings()
    {
        List<string> words = new List<string> { "banana", "apple", "pear", "orange", "grape" };
        
        Console.WriteLine("\nOriginal strings:");
        PrintList(words);
        
        SelectionSortStrings(words);
        
        Console.WriteLine("\nSorted strings:");
        PrintList(words);
    }
    
    static void SortChars()
    {
        List<char> characters = new List<char> { 'z', 'a', 'm', 'b', 'k', 'd' };
        
        Console.WriteLine("\nOriginal characters:");
        PrintList(characters);
        
        SelectionSortChars(characters);
        
        Console.WriteLine("\nSorted characters:");
        PrintList(characters);
    }
    
    // Selection Sort for numbers
    static void SelectionSort(List<int> list)
    {
        int n = list.Count;
        
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }
            
            if (minIndex != i)
            {
                int temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
        }
    }
    
    // Selection Sort for strings
    static void SelectionSortStrings(List<string> list)
    {
        int n = list.Count;
        
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (string.Compare(list[j], list[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }
            
            if (minIndex != i)
            {
                string temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
        }
    }
    
    // Selection Sort for characters
    static void SelectionSortChars(List<char> list)
    {
        int n = list.Count;
        
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }
            
            if (minIndex != i)
            {
                char temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
        }
    }
    
    // Generic print method
    static void PrintList<T>(List<T> list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}