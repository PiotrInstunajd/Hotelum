using Hotelum.Models;
using Hotelum.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hotelum.Services;

namespace Hotelum.Controllers
{
    [Route("api/hotelum")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
             _hotelService.Delete(id);

            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateHotelDto dto, [FromRoute] int id)
        {
            _hotelService.Update(id, dto);

            return Ok();
        }

        [HttpPost]
        public ActionResult CreateHotel([FromBody]CreateHotelDto dto)
        {
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

            return Ok(hotel);
        }

        //[HttpGet("{id}/rooms")]
        //public ActionResult<RoomsDto> GetById([FromRoute] Hotels id)
        //{
        //    var room = _hotelService.GetById(id);

        //    return Ok(room);
        //}

    }
}
