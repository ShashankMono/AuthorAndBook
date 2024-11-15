using AuthorAndBook.Models;

namespace BookAndBook.Repository
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public Book Add(Book Book);
        public Book Update(Book Book);
        public bool Delete(Book book);
    }
}
