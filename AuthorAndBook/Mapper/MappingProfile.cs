using AuthorAndBook.Dto;
using AuthorAndBook.Models;
using AutoMapper;
using System.Runtime.InteropServices;

namespace AuthorAndBook.Mapper
{
    public class MappingProfile : Profile
    {
     
        public MappingProfile() {

            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.TotalBooks, val => val.MapFrom(src => src.Books.Count));
            CreateMap<AuthorDto, Author>();

            CreateMap<AuthorDetails, AuthorDetailDto>()
                .ForMember(dest => dest.AuthorName, val => val.MapFrom(src => src.Author.Name));
            CreateMap<AuthorDetailDto, AuthorDetails>();

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, val => val.MapFrom(src => src.Author.Name));
            CreateMap<BookDto, Book>();
        }
    }
}
