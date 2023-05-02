using AutoMapper;

namespace TravelBnB_Web.Models
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Apartment,ApartmentDTO>().ReverseMap();
            CreateMap<Apartment,ApartmentCreateDTO>().ReverseMap();
            CreateMap<Apartment,ApartmentUpdateDTO>().ReverseMap();

            CreateMap<ApartmentNumber, ApartmentNumberDTO>().ReverseMap();
            CreateMap<ApartmentNumberDTO, ApartmentNumberCreateDTO>().ReverseMap();
            CreateMap<ApartmentNumber, ApartmentNumberUpdateDTO>().ReverseMap();
            CreateMap<ApartmentNumberCreateDTO,ApartmentNumber>().ReverseMap();

        }
    }
}
