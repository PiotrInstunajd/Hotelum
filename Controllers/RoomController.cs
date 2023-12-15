using Hotelum.Models;
using Hotelum.Services;
using Microsoft.AspNetCore.Mvc;
using static Hotelum.Services.RoomService;

namespace Hotelum.Controllers
{
    [Route("api/hotelum/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        //Delete room
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _roomService.Delete(id);

            return NoContent();
        }
        //Update of Room
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRoomDto dto, [FromRoute] int id)
        {
            _roomService.Update(id, dto);

            return Ok();
        }
        //Create Room
        [HttpPost]
        public ActionResult CreateRoom([FromBody]CreateRoomDto dto)
        {
            var id = _roomService.Create(dto);

            return Created($"/api/hotelum/rooms/{id}", null);
        }
        //Provide limited list of rooms for guests
        [HttpGet]
        public ActionResult<IEnumerable<RoomsDto>> GetAll()
        {
            var roomDtos = _roomService.GetAll();

            return Ok(roomDtos);
        }
        //Provide full information about room for guests
        [HttpGet("{id}")]
        public ActionResult<RoomsDto> Get([FromRoute] int id)
        {
            var room = _roomService.GetById(id);

            return Ok(room);
        }

    }
}
