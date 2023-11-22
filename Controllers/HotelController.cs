using Hotelum.Models;
using Hotelum.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hotelum.Services;

namespace Hotelum.Controllers
{
    [Route("api/hotelum")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public ActionResult CreateHotel([FromBody]CreateHotelDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _hotelService.Create(dto);

            return Created($"/api/hotelum/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotelsDto>> GetAll()
        {
            var hotelDtos = _hotelService.GetAll();

            return Ok(hotelDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<HotelsDto> Get([FromRoute] int id)
        {
            var hotel = _hotelService.GetById(id);

            if (hotel is null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }
    }
}
