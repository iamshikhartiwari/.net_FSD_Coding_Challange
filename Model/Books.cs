namespace Book_CodingChallange.Models;

public class Books
{
    public int Id { get; set; } 
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
}