using AuthorAndBook.Dto;
using AuthorAndBook.Models;

namespace AuthorAndBook.Services
{
    public interface IAuthorDetailsService
    {
        public List<AuthorDetailDto> GetAll();
        public AuthorDetailDto GetById(int id);
        public int Add(AuthorDetailDto detailDto);
        public AuthorDetailDto Update(AuthorDetailDto detailDto);
        public bool Delete(int id);
    }
}
