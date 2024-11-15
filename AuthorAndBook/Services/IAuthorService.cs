using AuthorAndBook.Dto;
using AuthorAndBook.Models;

namespace AuthorAndBook.Services
{
    public interface IAuthorService
    {
        public List<AuthorDto> GetAll();
        public AuthorDto GetById(int id);
        public int Add(AuthorDto authorDto);
        public AuthorDto Update(AuthorDto authorDto);
        public bool Delete (int id);
        public AuthorDto GetByName(string name);
        public AuthorDto GetDetailById(int id);
        public AuthorDto GetBooksByAuthorId(int id);
    }
}
