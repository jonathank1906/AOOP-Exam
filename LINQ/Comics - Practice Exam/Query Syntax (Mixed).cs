//css_nuget CsvHelper -ver:30.0.1
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using System.Linq;

public class Comic
{
    [Name("Title")]
    public string Title { get; set; } = string.Empty;
    
    [Name("Author")]
    public string Author { get; set; } = string.Empty;
    
    [Name("ReleaseYear")]
    public int Year { get; set; }
}

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

        // 3.1. Comics before 2000 (query syntax)
        Console.WriteLine("=== Comics released before 2000 ===");
        var comicsBefore2000 = 
            from comic in comics
            where comic.Year < 2000
            orderby comic.Year, comic.Title
            select comic;
        
        foreach (var comic in comicsBefore2000)
        {
            Console.WriteLine($"{comic.Year}: {comic.Title} by {comic.Author}");
        }
        Console.WriteLine();

        // 3.2. Number of comics by each author (query syntax)
        Console.WriteLine("=== Number of comics by each author ===");
        var authorComicCounts = 
            from comic in comics
            group comic by comic.Author into authorGroup
            orderby authorGroup.Count() descending, authorGroup.Key
            select new { Author = authorGroup.Key, Count = authorGroup.Count() };
        
        foreach (var item in authorComicCounts)
        {
            Console.WriteLine($"{item.Author,-20}: {item.Count} comics");
        }
        Console.WriteLine();

        // 3.3. Most active author by year (mixed syntax - some parts need method syntax)
        Console.WriteLine("=== Most active author by year ===");
        var mostActiveAuthorsByYear = 
            from yearGroup in (
                from comic in comics
                group comic by comic.Year into g
                select g
            )
            let authorGroups = (
                from comic in yearGroup
                group comic by comic.Author into g
                orderby g.Count() descending
                select g
            )
            let topAuthor = authorGroups.First()
            orderby yearGroup.Key
            select new {
                Year = yearGroup.Key,
                MostActiveAuthor = topAuthor.Key,
                ComicCount = topAuthor.Count()
            };
        
        foreach (var item in mostActiveAuthorsByYear)
        {
            Console.WriteLine($"{item.Year}: {item.MostActiveAuthor} ({item.ComicCount} comics)");
        }
    }
}