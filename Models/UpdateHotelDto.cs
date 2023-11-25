using System.ComponentModel.DataAnnotations;

namespace Hotelum.Models
{
    public class UpdateHotelDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsItOpen { get; set; }
    }
}
