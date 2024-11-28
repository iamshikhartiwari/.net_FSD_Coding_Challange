using Book_CodingChallange.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_CodingChallange.BooksDBContext
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}