using System;
using System.Collections.Generic;

// Implements IComparable using your preferred CompareTo(object obj) style
public class Book : IComparable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Book otherBook = obj as Book;
        if (otherBook != null)
            return this.YearPublished.CompareTo(otherBook.YearPublished);
        else
            throw new ArgumentException("Object is not a Book");
    }

    public override string ToString()
    {
        return $"{Title} by {Author} ({YearPublished})";
    }
}

class Program
{
    static void Main()
    {
        List<Book> library = new List<Book>
        {
            new Book { Title = "Brave New World", Author = "Aldous Huxley", YearPublished = 1932 },
            new Book { Title = "The Road", Author = "Cormac McCarthy", YearPublished = 2006 },
            new Book { Title = "1984", Author = "George Orwell", YearPublished = 1949 }
        };

        // Sort using IComparable (non-generic)
        library.Sort();

        Console.WriteLine("Books sorted by publication year:");
        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }
}
