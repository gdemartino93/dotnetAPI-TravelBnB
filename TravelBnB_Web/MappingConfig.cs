using AutoMapper;
using TravelBnB_Web.Models.ViewModel;

namespace TravelBnB_Web.Models
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {


            CreateMap<ApartmentDTO,ApartmentCreateDTO>().ReverseMap();
            CreateMap<ApartmentDTO,ApartmentUpdateDTO>().ReverseMap();

            CreateMap<ApartmentNumberDTO,ApartmentNumberCreateDTO>().ReverseMap();
            CreateMap<ApartmentNumberDTO, ApartmentNumberUpdateDTO>().ReverseMap();


            //DEBUG

            CreateMap<Apartment, ApartmentDTO>().ReverseMap();
            CreateMap<Apartment, ApartmentCreateDTO>().ReverseMap();
            CreateMap<Apartment, ApartmentUpdateDTO>().ReverseMap();

            CreateMap<ApartmentNumber, ApartmentNumberDTO>().ReverseMap();
            CreateMap<ApartmentNumberDTO, ApartmentNumberCreateDTO>().ReverseMap();



            CreateMap<ApartmentNumber, ApartmentNumberUpdateDTO>().ReverseMap();
            CreateMap<ApartmentNumberDTO, ApartmentNumberUpdateDTO>().ReverseMap();


            CreateMap<ApartmentNumberCreateDTO, ApartmentNumber>().ReverseMap();
        }
    }
}
