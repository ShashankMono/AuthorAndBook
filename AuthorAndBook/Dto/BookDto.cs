using AuthorAndBook.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorAndBook.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public DateTime PublishDate { get; set; }

        public Author Author { get; set; }
        public string? AuthorName { get; set; }
        public int AuthorId { get; set; }
    }
}
