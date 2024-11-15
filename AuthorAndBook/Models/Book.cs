using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorAndBook.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public DateTime PublishDate { get; set; }

        public Author? Author { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

    }
}
