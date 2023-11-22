using AutoMapper;
using Hotelum.Entities;
using Hotelum.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotelum.Services
{
    public interface IHotelService
    {
        int Create(CreateHotelDto dto);
        IEnumerable<HotelsDto> GetAll();
        HotelsDto GetById(int id);
    }

    public class HotelService : IHotelService
    {
        private readonly HotelsDbContext _dbContext;
        private readonly IMapper _mapper;

        public HotelService(HotelsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public HotelsDto GetById(int id)
        {
            var hotel = _dbContext
                .Hotels
                .Include(r => r.Address)
                .Include(r => r.Rooms)
                .FirstOrDefault(h => h.Id == id);

            if (hotel == null)
            {
                return null;
            }

            var result = _mapper.Map<HotelsDto>(hotel);
            return result;
        }

        public IEnumerable<HotelsDto> GetAll()
        {
            var hotels = _dbContext
                .Hotels
                .Include(r => r.Address)
                .Include(r => r.Rooms)
                .ToList();

            var hotelsDtos = _mapper.Map<List<HotelsDto>>(hotels);

            return hotelsDtos;
        }

        public int Create(CreateHotelDto dto)
        {
            var hotel = _mapper.Map<Hotels>(dto);
            _dbContext.Hotels.Add(hotel);
            _dbContext.SaveChanges();

            return hotel.Id;
        }
    }
}
