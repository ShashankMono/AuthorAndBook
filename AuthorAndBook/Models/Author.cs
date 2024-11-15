using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorAndBook.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public AuthorDetails? AuthorDetail { get; set; }
        public List<Book>? Books { get; set; }
    }
}
