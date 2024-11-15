using AuthorAndBook.Data;
using AuthorAndBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAndBook.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorAndBookContext _context;

        public AuthorRepository(AuthorAndBookContext context)
        {
            _context = context;
        }
        public Author Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public bool Delete(Author author)
        {

            _context.Authors.Remove(author);
            _context.SaveChanges();
            return true;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.AsNoTracking().Where(author => author.Id == id).FirstOrDefault();
        }

        public Author Update(Author author)
        {
            _context.Authors.Update(author);
            return author;
        }
    }
}
