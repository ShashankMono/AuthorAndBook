using AuthorAndBook.Models;

namespace AuthorAndBook.Repository
{
    public interface IAuthorRepository
    {
        public List<Author> GetAll();
        public Author GetById(int id);
        public Author Add(Author author);
        public Author Update(Author author);
        public bool Delete(Author author);
    }
}
