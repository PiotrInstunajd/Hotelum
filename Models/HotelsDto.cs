﻿using Hotelum.Entities;

namespace Hotelum.Models
{
    public class HotelsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsItOpen { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public List<RoomsDto> Rooms { get; set; }
    }
}
