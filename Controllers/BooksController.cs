using Book_CodingChallange.BooksDBContext;
using Book_CodingChallange.Dto;
using Book_CodingChallange.Models;
using Book_CodingChallange.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_CodingChallange.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _bookRepository;
        private readonly BookDBContext _context;  


        public BooksController(IBooksRepository bookRepository, BookDBContext context)
        {
            _bookRepository = bookRepository;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetAllBooks()
        {
            return _context.Books
                .Select(book => new BookReadDto
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Author = book.Author
                })
                .ToList();
            
        }

        [HttpGet("{isbn}")]
        public ActionResult<BookReadDto> GetBookByIsbn(string isbn)
        {
            Console.WriteLine($"Looking for book with ISBN: {isbn}");

            var book = _context.Books.SingleOrDefault(b => b.ISBN == isbn);
    
            if (book == null)
            {
                Console.WriteLine($"No book found with ISBN: {isbn}");
                return null;
            }

            return new BookReadDto
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author
            };
        }
        
        [HttpPost]
        public void AddBook(BookCreateDto bookDto)
        {
            var book = new Books
            {
                ISBN = bookDto.ISBN,
                Title = bookDto.Title,
                Author = bookDto.Author
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        [HttpPut("{isbn}")]
        public void UpdateBook(string isbn, BookUpdateDto bookDto)
        {
            var book = _context.Books
                .Where(b => b.ISBN == isbn)
                .FirstOrDefault();

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;

            _context.Books.Update(book);
            _context.SaveChanges();
        }

        [HttpDelete("{isbn}")]
        public void DeleteBook(string isbn)
        {
            var book = _context.Books
                .Where(b => b.ISBN == isbn)
                .FirstOrDefault();

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }


}
