using AuthorAndBook.Dto;
using AuthorAndBook.Models;
using AuthorAndBook.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorAndBook.Services
{
    public class AuthorDetailsService : IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetails> _repository;
        private readonly IMapper _mapper;
        public AuthorDetailsService(IRepository<AuthorDetails> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public int Add(AuthorDetailDto detailsDto)
        {
            var detail = _mapper.Map<AuthorDetails>(detailsDto);
            _repository.Add(detail);
            return detail.Id;
        }

        public bool Delete(int id)
        {
            var detailDto = GetById(id);
            if (detailDto != null) {
                var detail = _mapper.Map<AuthorDetails>(detailDto);
                _repository.Delete(detail);
                return true;
            }
            return false;
        }

        public List<AuthorDetailDto> GetAll()
        {
            var authrosDetails = _repository.GetAll().Include(d=>d.Author).ToList();
            var authorsDetailsDto = _mapper.Map<List<AuthorDetailDto>>(authrosDetails);
            return authorsDetailsDto;
        }

        public AuthorDetailDto GetById(int id)
        {
            var authorDetail = _repository.GetAll().AsNoTracking().Where(e => e.Id == id).FirstOrDefault();
            return _mapper.Map<AuthorDetailDto>(authorDetail);
        }

        public AuthorDetailDto Update(AuthorDetailDto detailDto)
        {
            var ExistingDetailDto = GetById(detailDto.Id);
            if (ExistingDetailDto != null)
            {
                var detail = _mapper.Map<AuthorDetails>(detailDto);

                return _mapper.Map<AuthorDetailDto>(_repository.Update(detail));
            }
            return ExistingDetailDto;
        }
    }
}
