
using AuthorAndBook.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorAndBook.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AuthorAndBookContext _context;
        private readonly DbSet<T> _table;
        public Repository(AuthorAndBookContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges(); 
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(int id)
        {

            return _table.Find(id);
        }

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
