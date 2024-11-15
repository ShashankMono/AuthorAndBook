using AuthorAndBook.Models;

namespace AuthorAndBook.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public AuthorDetails? AuthorDetail { get; set; }
        public List<Book>? Books { get; set; }
        public int TotalBooks { get; set; }
    }
}
