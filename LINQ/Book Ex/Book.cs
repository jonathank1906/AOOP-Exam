public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
    public List<string> Genres { get; set; } = new List<string>();

    // public override string ToString()
    // {
    //     return $"{Title} by {Author}";
    // }
}