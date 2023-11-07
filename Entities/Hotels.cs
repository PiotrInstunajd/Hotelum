namespace Hotelum.Entities
{
    public class Hotels
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public string Category {  get; set; }
        public int NumberOfRooms {  get; set; }
        public virtual List<Rooms> Rooms { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public bool IsItOpen { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
    }
}
