using AuthorAndBook.Models;

namespace AuthorAndBook.Repository
{
    public interface IAuthorDetailsRepository
    {
        public List<AuthorDetails> GetAll();
        public AuthorDetails GetById(int id);
        public AuthorDetails Add(AuthorDetails details);
        public AuthorDetails Update(AuthorDetails details);
        public bool Delete(AuthorDetails author);
    }
}
