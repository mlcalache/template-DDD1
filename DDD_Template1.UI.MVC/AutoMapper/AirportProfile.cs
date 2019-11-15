using AutoMapper;
using DDD_Template1.Domain;
using DDD_Template1.UI.MVC.Models;

namespace DDD_Template1.UI.MVC.AutoMapper
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<AirportViewModel, Airport>()
                .ForMember(dest => dest.continent, x => x.MapFrom(src => src.Continent))
                .ForMember(dest => dest.iata, x => x.MapFrom(src => src.IATA))
                .ForMember(dest => dest.iso, x => x.MapFrom(src => src.ISO))
                .ForMember(dest => dest.lat, x => x.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.lon, x => x.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.name, x => x.MapFrom(src => src.Name))
                .ForMember(dest => dest.size, x => x.MapFrom(src => src.Size))
                .ForMember(dest => dest.status, x => x.MapFrom(src => src.Status))
                .ForMember(dest => dest.type, x => x.MapFrom(src => src.Type));

            CreateMap<Airport, AirportViewModel>()
                .ForMember(dest => dest.Continent, x => x.MapFrom(src => src.continent))
                .ForMember(dest => dest.IATA, x => x.MapFrom(src => src.iata))
                .ForMember(dest => dest.ISO, x => x.MapFrom(src => src.iso))
                .ForMember(dest => dest.Latitude, x => x.MapFrom(src => src.lat))
                .ForMember(dest => dest.Longitude, x => x.MapFrom(src => src.lon))
                .ForMember(dest => dest.Name, x => x.MapFrom(src => src.name))
                .ForMember(dest => dest.Size, x => x.MapFrom(src => src.size))
                .ForMember(dest => dest.Status, x => x.MapFrom(src => src.status))
                .ForMember(dest => dest.Type, x => x.MapFrom(src => src.type));
        }
    }
}