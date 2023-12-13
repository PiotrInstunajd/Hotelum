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

            CreateMap<Room, RoomsDto>();

            CreateMap<CreateHotelDto, Hotels>()
                .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));

            CreateMap<CreateRoomDto, Room>()
                .ForMember(m => m.Id, c => c.MapFrom(s => s.HotelId));
            
        }
    }
}
