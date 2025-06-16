public class BookRatings
{
    public int BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
    public List<string> Genres { get; set; } = new List<string>();
    public double Rating { get; set; } // Changed to double to match rating type
}