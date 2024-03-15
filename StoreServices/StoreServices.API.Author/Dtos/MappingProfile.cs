using AutoMapper;

namespace StoreServices.API.Author.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Author, AuthorDto>();
        }
    }
}
