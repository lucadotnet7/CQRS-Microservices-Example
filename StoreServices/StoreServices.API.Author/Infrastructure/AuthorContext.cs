using Microsoft.EntityFrameworkCore;
using StoreServices.API.Author.Models;

namespace StoreServices.API.Author.Infrastructure
{
    public class AuthorContext : DbContext
    {
        public DbSet<Models.Author> Authors { get; set; }
        public DbSet<AcademicState> AcademicStates { get; set; }
        
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options)
        {
        }


    }
}
