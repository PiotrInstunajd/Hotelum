using Hotelum.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hotelum.Models
{
    public class CreateHotelDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsItOpen { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        [MaxLength(35)]
        public string City { get; set; }
        [Required]
        [MaxLength(35)]
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
