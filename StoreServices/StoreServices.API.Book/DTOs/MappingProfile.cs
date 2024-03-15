using AutoMapper;

namespace StoreServices.API.Book.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Book, BookDto>();
        }
    }
}
