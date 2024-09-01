using AutoMapper;

namespace Bangazon.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Mapis creating from the source Product class, the DTO is the destination.
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
