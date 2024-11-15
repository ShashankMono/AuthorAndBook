using AuthorAndBook.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorAndBook.Dto
{
    public class AuthorDetailDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }

        public string? AuthorName { get; set; }
        public int AuthorId { get; set; }
    }
}
