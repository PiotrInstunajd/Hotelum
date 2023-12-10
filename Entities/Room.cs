namespace Hotelum.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int NumberOfRooms { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int HotelId { get; set; }
        public virtual Hotels Hotels { get; set; }

    }
}
