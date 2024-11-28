using Book_CodingChallange.Dto;
using Book_CodingChallange.Models;

namespace Book_CodingChallange.Repository;

public class BooksRepository : IBooksRepository
{
    private readonly List<Books> _books = new();

    public IEnumerable<BookReadDto> GetAllBooks()
    {
        return _books.Select(b => new BookReadDto
        {
            Title = b.Title,
            Author = b.Author,
            ISBN = b.ISBN,
            PublicationYear = b.PublicationYear
        });
    }

    public BookReadDto GetBookByIsbn(string isbn)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null) return null;

        return new BookReadDto
        {
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            PublicationYear = book.PublicationYear
        };
    }

    public void AddBook(BookCreateDto bookDto)
    {
        var book = new Books
        {
            Id = _books.Count + 1,
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
            PublicationYear = bookDto.PublicationYear
        };
        _books.Add(book);
    }

    public void UpdateBook(string isbn, BookUpdateDto bookDto)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isbn);
        if (book != null)
        {
            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.PublicationYear = bookDto.PublicationYear;
        }
    }

    public void DeleteBook(string isbn)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isbn);
        if (book != null)
        {
            _books.Remove(book);
        }
    }
}