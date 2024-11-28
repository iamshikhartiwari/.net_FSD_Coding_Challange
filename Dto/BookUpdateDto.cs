namespace Book_CodingChallange.Dto;

public class BookUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
}