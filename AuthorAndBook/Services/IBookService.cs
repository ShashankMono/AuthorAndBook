using AuthorAndBook.Dto;
using AuthorAndBook.Models;

namespace AuthorAndBook.Services
{
    public interface IBookService
    {
        public List<BookDto> GetAll();
        public BookDto GetById(int id);
        public int Add(BookDto bookDto);
        public BookDto Update(BookDto bookDto);
        public bool Delete(int id);
        public BookDto GetAuthorByBookId(int id);

    }
}
