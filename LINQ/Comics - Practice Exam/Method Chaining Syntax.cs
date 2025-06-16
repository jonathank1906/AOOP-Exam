//css_nuget CsvHelper -ver:30.0.1
using System.Globalization;
using CsvHelper;
using System.Linq;
using CsvHelper.Configuration.Attributes;
class Program
{
    static void Main(string[] args)
    {
        // Read the CSV file
        List<Comic> comics;
        using (var reader = new StreamReader("comics.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            comics = csv.GetRecords<Comic>().ToList();
        }

        // 3.1. Comics before 2000 
        Console.WriteLine("=== Comics released before 2000 ===");
        var comicsBefore2000 = comics
            .Where(c => c.Year < 2000)
            .OrderBy(c => c.Year)
            .ThenBy(c => c.Title);

        foreach (var comic in comicsBefore2000)
        {
            Console.WriteLine($"{comic.Year}: {comic.Title} by {comic.Author}");
        }
        Console.WriteLine();
        
        // 3.2. Number of comics by each author
        Console.WriteLine("=== Number of comics by each author ===");
        var authorComicCounts = comics
            .GroupBy(c => c.Author)
            .Select(g => new { Author = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Author);

        foreach (var item in authorComicCounts)
        {
            Console.WriteLine($"{item.Author,-20}: {item.Count} comics");
        }
        Console.WriteLine();

        // 3.3. Most active author by year 
        Console.WriteLine("=== Most active author by year ===");
        var mostActiveAuthorsByYear = comics
            .GroupBy(c => c.Year)
            .Select(g => new
            {
                Year = g.Key,
                MostActiveAuthor = g
                    .GroupBy(c => c.Author)
                    .OrderByDescending(a => a.Count())
                    .First()
                    .Key,
                ComicCount = g
                    .GroupBy(c => c.Author)
                    .Max(a => a.Count())
            })
            .OrderBy(x => x.Year);

        foreach (var item in mostActiveAuthorsByYear)
        {
            Console.WriteLine($"{item.Year}: {item.MostActiveAuthor} ({item.ComicCount} comics)");
        }
    }
}



public class Comic
{
    [Name("Title")]
    public string Title { get; set; } = string.Empty;

    [Name("Author")]
    public string Author { get; set; } = string.Empty;

    [Name("ReleaseYear")]
    public int Year { get; set; }
}