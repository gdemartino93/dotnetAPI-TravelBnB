using AutoMapper;
using TravelBnB_API.Models;
using TravelBnB_API.Models.Dto;

namespace TravelBnB_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Apartment,ApartmentDTO>().ReverseMap();
            CreateMap<Apartment,ApartmentCreateDTO>().ReverseMap();
            CreateMap<Apartment,ApartmentUpdateDTO>().ReverseMap();
        }
    }
}
