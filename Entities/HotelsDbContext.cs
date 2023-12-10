using Microsoft.EntityFrameworkCore;

namespace Hotelum.Entities
{
    public class HotelsDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=HotelumDb;Trusted_Connection=True;";
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotels>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Room>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(c => c.City)
                .IsRequired()
                .HasMaxLength(35);

            modelBuilder.Entity<Address>()
                .Property(s => s.Street)
                .IsRequired()
                .HasMaxLength(35);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
