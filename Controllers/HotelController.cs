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
        private readonly HotelsDbContext _dbcontext;
        private readonly IMapper _mapper;
        public HotelController(HotelsDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
        }
        public ActionResult<IEnumerable<HotelsDto>> GetAll()
        {
            var hotels = _dbcontext
                .Hotels
                .Include(r => r.Address)
                .Include(r => r.Rooms)
                .ToList();

            var hotelsDtos = _mapper.Map<List<HotelsDto>>(hotels);


            return Ok(hotelsDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<Hotels> Get([FromRoute] int id)
        {
            var hotels = _dbcontext
                .Hotels
                .Include(r => r.Address)
                .Include(r => r.Rooms)
                .FirstOrDefault(h => h.Id == id);

            if (hotels == null)
            {
                return NotFound();
            }

            var hotelsDtos = _mapper.Map<HotelsDto>(hotels);
            return Ok(hotels);
        }
    }
}
