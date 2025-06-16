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
        
        QuickSort(numbers, 0, numbers.Count - 1);
        
        Console.WriteLine("\nSorted numbers:");
        PrintList(numbers);
    }
    
    static void SortStrings()
    {
        List<string> words = new List<string> { "banana", "apple", "pear", "orange", "grape" };
        
        Console.WriteLine("\nOriginal strings:");
        PrintList(words);
        
        QuickSortStrings(words, 0, words.Count - 1);
        
        Console.WriteLine("\nSorted strings:");
        PrintList(words);
    }
    
    static void SortChars()
    {
        List<char> characters = new List<char> { 'z', 'a', 'm', 'b', 'k', 'd' };
        
        Console.WriteLine("\nOriginal characters:");
        PrintList(characters);
        
        QuickSortChars(characters, 0, characters.Count - 1);
        
        Console.WriteLine("\nSorted characters:");
        PrintList(characters);
    }
    
    // QuickSort for numbers
    static void QuickSort(List<int> list, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = PartitionNumbers(list, low, high);
            QuickSort(list, low, partitionIndex - 1);
            QuickSort(list, partitionIndex + 1, high);
        }
    }
    
    static int PartitionNumbers(List<int> list, int low, int high)
    {
        int pivot = list[high];
        int i = low - 1;
        
        for (int j = low; j < high; j++)
        {
            if (list[j] < pivot)
            {
                i++;
                Swap(list, i, j);
            }
        }
        
        Swap(list, i + 1, high);
        return i + 1;
    }
    
    // QuickSort for strings
    static void QuickSortStrings(List<string> list, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = PartitionStrings(list, low, high);
            QuickSortStrings(list, low, partitionIndex - 1);
            QuickSortStrings(list, partitionIndex + 1, high);
        }
    }
    
    static int PartitionStrings(List<string> list, int low, int high)
    {
        string pivot = list[high];
        int i = low - 1;
        
        for (int j = low; j < high; j++)
        {
            if (string.Compare(list[j], pivot) < 0)
            {
                i++;
                Swap(list, i, j);
            }
        }
        
        Swap(list, i + 1, high);
        return i + 1;
    }
    
    // QuickSort for characters
    static void QuickSortChars(List<char> list, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = PartitionChars(list, low, high);
            QuickSortChars(list, low, partitionIndex - 1);
            QuickSortChars(list, partitionIndex + 1, high);
        }
    }
    
    static int PartitionChars(List<char> list, int low, int high)
    {
        char pivot = list[high];
        int i = low - 1;
        
        for (int j = low; j < high; j++)
        {
            if (list[j] < pivot)
            {
                i++;
                Swap(list, i, j);
            }
        }
        
        Swap(list, i + 1, high);
        return i + 1;
    }
    
    // Generic swap method
    static void Swap<T>(List<T> list, int i, int j)
    {
        T temp = list[i];
        list[i] = list[j];
        list[j] = temp;
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