namespace AuthorAndBook.Repository
{
    public interface IRepository<T>
    {
        public T GetById(int id);
        public int Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);
        public IQueryable<T> GetAll();
    }
}
