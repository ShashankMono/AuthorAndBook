using AuthorAndBook.Data;
using AuthorAndBook.Models;
using BookAndBook.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookAndBook.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AuthorAndBookContext _context;

        public BookRepository(AuthorAndBookContext context)
        {
            _context = context;
        }
        public Book Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public bool Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.AsNoTracking().Where(book => book.Id == id).FirstOrDefault();
        }

        public Book Update(Book book)
        {
            _context.Books.Update(book);
            return book;
        }
    }
}
