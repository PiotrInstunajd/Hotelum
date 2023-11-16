using Hotelum.Models;
using Hotelum.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Hotelum.Controllers
{
    [Route("api/hotelum")]
    public class HotelController : ControllerBase
    {
        private readonly HotelsDbContext _dbContext;
        private readonly IMapper _mapper;
        public HotelController(HotelsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateHotel([FromBody]CreateHotelDto dto)
        {
            var hotel = _mapper.Map<Hotels>(dto);
            _dbContext.Hotels.Add(hotel);
            _dbContext.SaveChanges();

            return Created($"/api/hotelum/{hotel.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotelsDto>> GetAll()
        {
            var hotels = _dbContext
                .Hotels
                .Include(r => r.Address)
                .Include(r => r.Rooms)
                .ToList();

            var hotelsDtos = _mapper.Map<List<HotelsDto>>(hotels);

            return Ok(hotelsDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<HotelsDto> Get([FromRoute] int id)
        {
            var hotels = _dbContext
                .Hotels
                .Include(r => r.Address)
                .Include(r => r.Rooms)
                .FirstOrDefault(h => h.Id == id);

            if (hotels is null)
            {
                return NotFound();
            }

            var hotelsDtos = _mapper.Map<HotelsDto>(hotels);
            return Ok(hotelsDtos);
        }
    }
}
