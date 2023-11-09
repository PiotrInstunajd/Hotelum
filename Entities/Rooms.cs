namespace Hotelum.Entities
{
    public class Rooms
    {
        public int Id { get; set; }
        public int NumberOfRooms { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public virtual Hotels Hotels { get; set; }

    }
}
