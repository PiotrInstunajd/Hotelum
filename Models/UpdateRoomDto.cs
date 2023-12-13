using System.ComponentModel.DataAnnotations;

namespace Hotelum.Models
{
    public class UpdateRoomDto
    {
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
