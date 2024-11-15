using AuthorAndBook.Dto;
using AuthorAndBook.Models;
using AuthorAndBook.Repository;
using AutoMapper;
using Azure.Core;
using BookAndBook.Repository;
using Microsoft.EntityFrameworkCore;

namespace AuthorAndBook.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;
        public BookService(IRepository<Book> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public int Add(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _repository.Add(book);
            return book.Id;
        }

        public bool Delete(int id)
        {

            var bookDto = GetById(id);
            if (bookDto != null)
            {
                var book = _mapper.Map<Book>(bookDto);
                _repository.Delete(book);
                return true;
            }
            return false;
        }

        public List<BookDto> GetAll()
        {
            var books = _repository.GetAll().Include(b=>b.Author).ToList();
            return _mapper.Map<List<BookDto>>(books);
        }

        public BookDto GetById(int id)
        {
            var book =_repository.GetAll().AsNoTracking().Where(e => e.Id == id).FirstOrDefault();
            return _mapper.Map<BookDto>(book);
        }

        public BookDto Update(BookDto bookDto)
        {

            var existingBook = GetById(bookDto.Id);
            if (existingBook != null)
            {
                var book = _mapper.Map<Book>(bookDto);
                _repository.Update(book);
                return _mapper.Map<BookDto>(book);
            }
            return existingBook;
        }

        public BookDto GetAuthorByBookId(int id)
        {
            return _mapper.Map<BookDto>(_repository.GetAll()
                .AsNoTracking().Include(b => b.Author).FirstOrDefault(b => b.Id == id));
        }
    }
}
