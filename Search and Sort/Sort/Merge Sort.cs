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
        
        MergeSort(numbers, 0, numbers.Count - 1);
        
        Console.WriteLine("\nSorted numbers:");
        PrintList(numbers);
    }
    
    static void SortStrings()
    {
        List<string> words = new List<string> { "banana", "apple", "pear", "orange", "grape" };
        
        Console.WriteLine("\nOriginal strings:");
        PrintList(words);
        
        MergeSortStrings(words, 0, words.Count - 1);
        
        Console.WriteLine("\nSorted strings:");
        PrintList(words);
    }
    
    static void SortChars()
    {
        List<char> characters = new List<char> { 'z', 'a', 'm', 'b', 'k', 'd' };
        
        Console.WriteLine("\nOriginal characters:");
        PrintList(characters);
        
        MergeSortChars(characters, 0, characters.Count - 1);
        
        Console.WriteLine("\nSorted characters:");
        PrintList(characters);
    }
    
    // Merge Sort for numbers
    static void MergeSort(List<int> list, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);
            MergeNumbers(list, left, mid, right);
        }
    }
    
    static void MergeNumbers(List<int> list, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        List<int> leftArray = new List<int>(n1);
        List<int> rightArray = new List<int>(n2);

        for (int x = 0; x < n1; x++)
            leftArray.Add(list[left + x]);
        for (int y = 0; y < n2; y++)
            rightArray.Add(list[mid + 1 + y]);

        int i = 0, j = 0, k = left;
        
        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                list[k] = leftArray[i];
                i++;
            }
            else
            {
                list[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            list[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            list[k] = rightArray[j];
            j++;
            k++;
        }
    }
    
    // Merge Sort for strings
    static void MergeSortStrings(List<string> list, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSortStrings(list, left, mid);
            MergeSortStrings(list, mid + 1, right);
            MergeStrings(list, left, mid, right);
        }
    }
    
    static void MergeStrings(List<string> list, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        List<string> leftArray = new List<string>(n1);
        List<string> rightArray = new List<string>(n2);

        for (int x = 0; x < n1; x++)
            leftArray.Add(list[left + x]);
        for (int y = 0; y < n2; y++)
            rightArray.Add(list[mid + 1 + y]);

        int i = 0, j = 0, k = left;
        
        while (i < n1 && j < n2)
        {
            if (string.Compare(leftArray[i], rightArray[j]) <= 0)
            {
                list[k] = leftArray[i];
                i++;
            }
            else
            {
                list[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            list[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            list[k] = rightArray[j];
            j++;
            k++;
        }
    }
    
    // Merge Sort for characters
    static void MergeSortChars(List<char> list, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSortChars(list, left, mid);
            MergeSortChars(list, mid + 1, right);
            MergeChars(list, left, mid, right);
        }
    }
    
    static void MergeChars(List<char> list, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        List<char> leftArray = new List<char>(n1);
        List<char> rightArray = new List<char>(n2);

        for (int x = 0; x < n1; x++)
            leftArray.Add(list[left + x]);
        for (int y = 0; y < n2; y++)
            rightArray.Add(list[mid + 1 + y]);

        int i = 0, j = 0, k = left;
        
        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                list[k] = leftArray[i];
                i++;
            }
            else
            {
                list[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            list[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            list[k] = rightArray[j];
            j++;
            k++;
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