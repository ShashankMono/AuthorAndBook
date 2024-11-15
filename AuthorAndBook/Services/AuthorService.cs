using AuthorAndBook.Dto;
using AuthorAndBook.Models;
using AuthorAndBook.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorAndBook.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public int Add(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _repository.Add(author);
            return author.Id;
        }

        public bool Delete(int id)
        {
            var existingAuthor = GetById( id);
            
            if (existingAuthor != null) { 
                var author = _mapper.Map<Author>(existingAuthor);
                _repository.Delete(author);
                return true;
            }
            return false;
        }

        public List<AuthorDto> GetAll()
        {
            var authors =  _repository.GetAll().Include(a=>a.Books).Include(a=>a.AuthorDetail).ToList();
            var authorDto = _mapper.Map<List<AuthorDto>>(authors);
            return authorDto;
        }

        public AuthorDto GetById(int id)
        {
            var author = _repository.GetAll().AsNoTracking().Where(e=>e.Id==id).FirstOrDefault();
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        public AuthorDto Update(AuthorDto authorDto)
        {
            var existingAuthor = GetById(authorDto.Id);
            if (existingAuthor != null)
            {
                var author = _mapper.Map<Author>(authorDto);
                authorDto = _mapper.Map<AuthorDto>(_repository.Update(author));
                return authorDto;
            }
            return existingAuthor;
        }
        public AuthorDto GetByName(string name)
        {
            return _mapper.Map<AuthorDto>(_repository.GetAll()
                .AsNoTracking().FirstOrDefault(a=>a.Name.ToLower() == name.ToLower()));
        }

        public AuthorDto GetDetailById(int id)
        {
            return _mapper.Map<AuthorDto>(_repository.GetAll()
                .AsNoTracking().Include(a=>a.AuthorDetail).FirstOrDefault(a=>a.Id == id));
        }

        public AuthorDto GetBooksByAuthorId(int id)
        {
            return _mapper.Map<AuthorDto>(_repository.GetAll()
                .AsNoTracking().Include(a=>a.Books).FirstOrDefault(a=>a.Id == id));
        }
    }
}
