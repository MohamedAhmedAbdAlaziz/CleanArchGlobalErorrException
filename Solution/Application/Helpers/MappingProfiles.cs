
using Application.DTOs;
using AutoMapper;
using Core.Models;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BaseEntity, BaseEntityDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<Book, BookDTO>()
                 .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name)).ReverseMap();






        }
    }
}
