using Microsoft.EntityFrameworkCore;

namespace StoreServices.API.Book.Infrastructure
{
    public class BookContext : DbContext
    {
        public DbSet<Models.Book> Books { get; set; }
        
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
    }
}
