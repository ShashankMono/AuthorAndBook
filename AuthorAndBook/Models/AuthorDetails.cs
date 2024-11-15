using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorAndBook.Models
{
    public class AuthorDetails
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }

        public Author? Author { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}
