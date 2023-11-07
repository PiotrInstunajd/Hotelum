namespace Hotelum.Entities
{
    public class Rooms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int RoomsId { get; set; }
        public virtual Hotels Hotels { get; set; }

    }
}
