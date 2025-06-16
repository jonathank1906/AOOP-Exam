using CsvHelper.Configuration.Attributes;
public class Rating
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    [Name("Rating")]
    public int rating { get; set; }
}