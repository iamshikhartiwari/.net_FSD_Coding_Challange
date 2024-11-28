using Book_CodingChallange.Dto;

namespace Book_CodingChallange.Repository;

public interface IBooksRepository
{
    IEnumerable<BookReadDto> GetAllBooks();
    BookReadDto GetBookByIsbn(string isbn);
    void AddBook(BookCreateDto bookDto);
    void UpdateBook(string isbn, BookUpdateDto bookDto);
    void DeleteBook(string isbn);
}