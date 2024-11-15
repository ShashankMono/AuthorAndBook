
using AuthorAndBook.Data;
using AuthorAndBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAndBook.Repository
{
    public class AuthorDetailsRepository : IAuthorDetailsRepository
    {
        private readonly AuthorAndBookContext _context;

        public AuthorDetailsRepository(AuthorAndBookContext context)
        {
            _context = context;
        }
        public AuthorDetails Add(AuthorDetails details)
        {
            _context.AuthorDetails.Add(details);
            _context.SaveChanges();
            return details;
        }

        public bool Delete(AuthorDetails details)
        {
            _context.AuthorDetails.Remove(details);
            _context.SaveChanges();
            return true;
        }

        public List<AuthorDetails> GetAll()
        {
            return _context.AuthorDetails.ToList();
        }

        public AuthorDetails GetById(int id)
        {
            return _context.AuthorDetails.AsNoTracking().Where(detail => detail.Id == id).FirstOrDefault();
        }

        public AuthorDetails Update(AuthorDetails details)
        {
            _context.AuthorDetails.Update(details);
            _context.SaveChanges();
            return details;
        }
    }
}
