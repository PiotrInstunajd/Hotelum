using AutoMapper;
using Hotelum.Entities;
using Hotelum.Models;

namespace Hotelum
{
    public class HotelsMappingProfile : Profile
    {
        public HotelsMappingProfile()
        {
            CreateMap<Hotels, HotelsDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Rooms, RoomsDto>();
        }
    }
}
