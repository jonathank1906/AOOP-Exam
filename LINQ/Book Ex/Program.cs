//css_nuget CsvHelper
//css_include Book.cs
//css_include Rating.cs
//css_include DataLoader.cs
//css_include BookRatings.cs

class Program
{
    static void Main()
    {
        // Read the CSV files into two collections
        DataLoader<Book> movieLoader = new DataLoader<Book>();
        movieLoader.LoadData("books.csv");

        DataLoader<Rating> ratingLoader = new DataLoader<Rating>();
        ratingLoader.LoadData("ratings.csv");

        List<Book> Books = new List<Book>();
        Books = movieLoader.data;

        List<Rating> Ratings = new List<Rating>();
        Ratings = ratingLoader.data;

        // Verify output (loaded data correctly)
        foreach (Book b in Books) Console.WriteLine($"{b.Title} by {b.Author}");
        foreach (Rating r in Ratings) Console.WriteLine($"{r.UserId} - {r.BookId} - {r.rating}");

        // 1. Merge the two datasets using Join
        List<BookRatings> bookRatings = []; // The list will hold the combined data (not including the IDs).

        bookRatings = Books.Join(
         Ratings,
         book => book.BookId,
         rating => rating.BookId, // Changed from Rating.BookId to rating.BookId
         (book, rating) => new BookRatings
         {
             BookId = book.BookId,
             Title = book.Title,
             Author = book.Author,
             Year = book.Year,
             Genres = book.Genres, // This will need to be split later
             Rating = rating.rating // Changed from Rating.rating to rating.rating
         }).ToList();

        // Verify the join worked
        Console.WriteLine("\nMerged Book Ratings:");
        foreach (var br in bookRatings.Take(100)) // Take() controls how many are printed out
        {
            Console.WriteLine($"{br.Title} - Rating: {br.Rating}");
        }

        // 2. Calculate average rating for each book
        // Modified Task 2 solution to include all needed properties
        var averageRatingsPerBook = bookRatings
            .GroupBy(br => new { br.BookId, br.Title, br.Author, br.Year, br.Genres })
            .Select(group => new
            {
                BookId = group.Key.BookId,
                Title = group.Key.Title,
                Author = group.Key.Author,
                Year = group.Key.Year,
                Genres = group.Key.Genres,
                AverageRating = group.Average(r => r.Rating),
                RatingCount = group.Count()
            })
            .OrderByDescending(x => x.AverageRating)
            .ToList();

        // Display results
        Console.WriteLine("\n2. Average rating per book:");
        foreach (var book in averageRatingsPerBook)
        {
            Console.WriteLine($"{book.Title} by {book.Author}: {book.AverageRating:F2} (from {book.RatingCount} ratings)");
        }

        // 3. Top 10 highest rated books (ordered by average rating descending)
        var top50Books = averageRatingsPerBook
      .OrderByDescending(b => b.AverageRating)
      .Take(50)
      .ToList();

        Console.WriteLine("\n3. Top 50 Highest Rated Books:");
        Console.WriteLine("Rank | Title | Author | Avg Rating");
        Console.WriteLine("----------------------------------");
        int rank = 1;
        foreach (var book in top50Books)
        {
            Console.WriteLine($"{rank}. {book.Title} | {book.Author} | {book.AverageRating:F2}");
            rank++;
        }

        // 4. 
        var top50WithMinRatings = averageRatingsPerBook
            .Where(b => b.RatingCount >= 5)
            .OrderByDescending(b => b.AverageRating)
            .Take(50)
            .ToList();

        Console.WriteLine("\n4. Top 50 Books (Minimum 5 Ratings):");
        Console.WriteLine("Title | Author | Avg Rating | # Ratings");
        Console.WriteLine("----------------------------------------");
        foreach (var book in top50WithMinRatings)
        {
            Console.WriteLine($"{book.Title} | {book.Author} | {book.AverageRating:F2} | {book.RatingCount}");
        }

        // 5.
        Console.WriteLine("\n5. Genre List Sample (First 5 Books):");
        foreach (var book in bookRatings.Take(5))
        {
            Console.WriteLine($"{book.Title}: {string.Join(", ", book.Genres)}");
        }

        // 6.
        var genreDistribution = top50WithMinRatings
            .SelectMany(b => b.Genres)
            .GroupBy(g => g)
            .Select(g => new
            {
                Genre = g.Key,
                Percentage = (double)g.Count() / top50WithMinRatings.Count * 100
            })
            .OrderByDescending(g => g.Percentage);

        Console.WriteLine("\n6. Genre Distribution in Top 50:");
        Console.WriteLine("Genre | Percentage");
        Console.WriteLine("------------------");
        foreach (var genre in genreDistribution)
        {
            Console.WriteLine($"{genre.Genre} | {genre.Percentage:F1}%");
        }

        // 7.
        var modernHighlyRated = averageRatingsPerBook
          .Where(b => b.Year > 1950 && b.AverageRating > 4.0)
          .OrderByDescending(b => b.AverageRating);

        Console.WriteLine("\n7. Modern Highly Rated Books (Post-1950, Rating > 4.0):");
        Console.WriteLine("Title | Author | Year | Avg Rating");
        Console.WriteLine("-----------------------------------");
        foreach (var book in modernHighlyRated)
        {
            Console.WriteLine($"{book.Title} | {book.Author} | {book.Year} | {book.AverageRating:F2}");
        }

        // 8.
        var topAuthor = top50WithMinRatings
    .GroupBy(b => b.Author)
    .OrderByDescending(g => g.Count())
    .First();

        Console.WriteLine("\n8. Most Common Author in Top 50:");
        Console.WriteLine($"{topAuthor.Key} ({topAuthor.Count()} books)");

        // 9.
        var byDecade = averageRatingsPerBook
    .GroupBy(b => (b.Year / 10) * 10)
    .Select(g => new
    {
        Decade = $"{g.Key}s",
        AvgRating = g.Average(b => b.AverageRating),
        BookCount = g.Count()
    })
    .OrderBy(d => d.Decade);

        Console.WriteLine("\n9. Average Rating by Decade:");
        Console.WriteLine("Decade | Avg Rating | # Books");
        Console.WriteLine("-----------------------------");
        foreach (var decade in byDecade)
        {
            Console.WriteLine($"{decade.Decade} | {decade.AvgRating:F2} | {decade.BookCount}");
        }

        // 10.
        var fictionClassics = averageRatingsPerBook
    .Where(b => b.Genres.Contains("Fiction") && b.Genres.Contains("Classic"))
    .ToList();

        Console.WriteLine("\n10. Fiction Classics:");
        Console.WriteLine("Title | Author | Year");
        Console.WriteLine("----------------------");
        foreach (var book in fictionClassics)
        {
            Console.WriteLine($"{book.Title} | {book.Author} | {book.Year}");
        }
    }
}

/*
Tasks:
1. Merge the books and ratings collections using a LINQ join

2. Calculate the average rating for each book

3. Find the top 10 highest rated books (ordered by average rating descending)

4. Modify the query to only include books with at least 5 ratings

5. Split the genres string into a list of genres for each book

6. For the top 50 books (with minimum 5 ratings), calculate the percentage of each genre

7. Find all books published after 1950 with an average rating above 4.0

8. Find the author with the most books in the top 50 list

9. Calculate the average rating for books by decade

10. Find books that contain both "Fiction" and "Classic" in their genres
*/