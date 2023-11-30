using AutoMapper;
using Hotelum.Entities;
using Hotelum.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions;

namespace Hotelum.Services
{
    public interface IHotelService
    {
        int Create(CreateHotelDto dto);
        IEnumerable<HotelsDto> GetAll();
        HotelsDto GetById(int id);
        bool Delete(int id);
        bool Update(int id, UpdateHotelDto dto);
    }
    public class HotelService : IHotelService
    {
        private readonly HotelsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<HotelService> _logger;

        public HotelService(HotelsDbContext dbContext, IMapper mapper, ILogger<HotelService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;

        }
        public bool Delete(int id)
        {
            _logger.LogError($"Hotel with id: {id} DELETE action invoked");

            var hotel = _dbContext
                .Hotels
                .FirstOrDefault(h => h.Id == id);

            if (hotel is null) return false;

            _dbContext.Hotels.Remove(hotel);
            _dbContext.SaveChanges();

            return true;
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
        public bool Update(int id, UpdateHotelDto dto)
        {
            var hotel = _dbContext
                .Hotels
                .FirstOrDefault(h => h.Id == id);

            if (hotel is null) return false;

            hotel.Name = dto.Name;
            hotel.Description = dto.Description;
            hotel.IsItOpen = dto.IsItOpen;

            _dbContext.SaveChanges();

            return true;
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
