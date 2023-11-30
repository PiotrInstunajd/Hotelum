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
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _hotelService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateHotelDto dto, [FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _hotelService.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
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
