using AuthorAndBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAndBook.Data
{
    public class AuthorAndBookContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorDetails> AuthorDetails { get; set; }

        public AuthorAndBookContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
