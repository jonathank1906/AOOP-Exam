using System;

class BinarySearch
{
    // Iterative implementation of binary search
    public static int Search(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Prevents potential overflow

            if (array[mid] == target)
            {
                return mid;
            }
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1; // Target not found
    }

    // Recursive implementation of binary search
    public static int SearchRecursive(int[] array, int target, int left, int right)
    {
        if (left > right)
        {
            return -1;
        }

        int mid = left + (right - left) / 2;

        if (array[mid] == target)
        {
            return mid;
        }
        else if (array[mid] < target)
        {
            return SearchRecursive(array, target, mid + 1, right);
        }
        else
        {
            return SearchRecursive(array, target, left, mid - 1);
        }
    }

    // Generic version of binary search
    public static int Search<T>(T[] array, T target) where T : IComparable<T>
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = array[mid].CompareTo(target);

            if (comparison == 0)
            {
                return mid;
            }
            else if (comparison < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    public static void Main(string[] args)
    {
        // Array must be sorted for binary search
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int target = 7;

        // Using iterative approach
        int result = Search(numbers, target);
        PrintResult(target, result);

        // Using recursive approach
        int recursiveResult = SearchRecursive(numbers, target, 0, numbers.Length - 1);
        PrintResult(target, recursiveResult);

        // Using generic version with strings
        string[] names = { "Alice", "Bob", "Charlie", "David", "Eve" };
        string nameTarget = "David";

        int genericResult = Search(names, nameTarget);
        if (genericResult != -1)
        {
            Console.WriteLine($"Name '{nameTarget}' found at index {genericResult}");
        }
        else
        {
            Console.WriteLine($"Name '{nameTarget}' not found");
        }
    }

    private static void PrintResult(int target, int result)
    {
        if (result != -1)
        {
            Console.WriteLine($"Element {target} found at index {result}");
        }
        else
        {
            Console.WriteLine($"Element {target} not found in the array");
        }
    }
}