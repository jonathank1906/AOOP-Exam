using System;

class SequentialSearch
{
    // Method to perform sequential search
    public static int Search(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                return i; // Return the index if found
            }
        }
        return -1; // Return -1 if not found
    }

    // Method to perform sequential search with generics (works with any comparable type)
    public static int Search<T>(T[] array, T target) where T : IComparable<T>
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].CompareTo(target) == 0)
            {
                return i;
            }
        }
        return -1;
    }

    public static void Main(string[] args)
    {
        // Example usage
        int[] numbers = { 4, 2, 7, 1, 9, 5, 3 };
        int target = 9;

        int result = Search(numbers, target);

        if (result != -1)
        {
            Console.WriteLine($"Element {target} found at index {result}");
        }
        else
        {
            Console.WriteLine($"Element {target} not found in the array");
        }

        // Example with generic version
        string[] names = { "Alice", "Bob", "Charlie", "David" };
        string nameTarget = "Charlie";

        int nameResult = Search(names, nameTarget);

        if (nameResult != -1)
        {
            Console.WriteLine($"Name {nameTarget} found at index {nameResult}");
        }
        else
        {
            Console.WriteLine($"Name {nameTarget} not found in the array");
        }
    }
}