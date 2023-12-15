using AutoMapper;
using Hotelum.Entities;
using Hotelum.Exceptions;
using Hotelum.Models;

namespace Hotelum.Services
{
        public interface IRoomService
        {
            int Create(CreateRoomDto dto);
            IEnumerable<RoomsDto> GetAll();
            RoomsDto GetById(int id);
            void Delete(int id);
            void Update(int id, UpdateRoomDto dto);
        }

        public class RoomService : IRoomService
        {
            private readonly HotelsDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly ILogger<RoomService> _logger;

            public RoomService(HotelsDbContext dbContext, IMapper mapper, ILogger<RoomService> logger)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _logger = logger;

            }
            //Delete Dish
            public void Delete(int id)
            {
                _logger.LogError($"Room with id: {id} DELETE action invoked");

                var room = _dbContext
                    .Hotels
                    .FirstOrDefault(h => h.Id == id);

                if (room is null)
                    throw new NotFoundException("Room not found");

                _dbContext.Hotels.Remove(room);
                _dbContext.SaveChanges();
            }
            //Provide full information about Dish
            public RoomsDto GetById(int id)
            {
                var room = _dbContext
                    .Rooms
                    .FirstOrDefault(h => h.Id == id);

                if (room == null)
                    throw new NotFoundException("Room not found");

                var result = _mapper.Map<RoomsDto>(room);
                return result;
            }

            //Provide limited list of Dishes for guest 
            public IEnumerable<RoomsDto> GetAll()
            {
                var rooms = _dbContext
                    .Rooms
                    .ToList();

                var roomsDtos = _mapper.Map<List<RoomsDto>>(rooms);

                return roomsDtos;
            }
            //Update of Dishes
            public void Update(int id, UpdateRoomDto dto)
            {
                var room = _dbContext
                    .Rooms
                    .FirstOrDefault(h => h.Id == id);

                if (room is null)
                    throw new NotFoundException("Room not found");

                room.Name = dto.Name;
                room.Description = dto.Description;
                room.Price = dto.Price;

                _dbContext.SaveChanges();
            }
            //Create Dish
            public int Create(CreateRoomDto dto)
            {
                var room = _mapper.Map<Room>(dto);
                _dbContext.Rooms.Add(room);
                _dbContext.SaveChanges();

                return room.Id;
            }

        }
    
}
