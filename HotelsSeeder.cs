﻿using Hotelum.Entities;

namespace Hotelum
{
    public class HotelsSeeder
    {

        private readonly HotelsDbContext _dbContext;

        public HotelsSeeder(HotelsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Hotels.Any())
                {
                    var hotel = GetHotels();
                    _dbContext.Hotels.AddRange(hotel);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Hotels> GetHotels()
        {
            var hotel = new List<Hotels> {
            new Hotels()
            {
                Name = "Avocado",
                Description = "Perfect for family, chill and drinks",
                Category = "Holidays",
                IsItOpen = true,
                ContactEmail = "contact@avocado.com",
                ContactNumber = "123456789",
                Rooms = new List<Room>()
                {
                    new Room()
                    {
                        Name = "Król",
                        Description = "Dla bogatych",
                        Price = 8549098M,
                        NumberOfRooms = 1,
                        HotelsId = 1,
                    },
                    new Room()
                    {
                        Name = "Królowa",
                        Description = "Dla mniej bogatych",
                        Price = 89098M,
                        NumberOfRooms = 5,
                        HotelsId = 1,
                    },
                    new Room()
                    {
                        Name = "Standart",
                        Description = "Dla standartów",
                        Price = 88M,
                        NumberOfRooms = 25,
                        HotelsId = 1,
                    },
                    },
                    Address = new Address()
                    {
                        City = "Wwa",
                        Street = "Poznanska",
                        PostalCode = "10-092"
                    }
                    },
                    new Hotels()
                    {
                        Name = "Abada",
                        Description = "Perfect for horrors",
                        Category = "Horros",
                        IsItOpen = true,
                        ContactEmail = "contact@abada.com",
                        ContactNumber = "123456789",
                    Rooms = new List<Room>
                    {
                        new Room()
                        {
                            Name = "Bieda",
                            Description = "Dla odważnych",
                            Price = 8M,
                            NumberOfRooms = 1,
                            HotelsId = 2,
                        },
                        new Room()
                        {
                            Name = "Mniejsza bieda",
                            Description = "Dla normalnych",
                            Price = 98M,
                            NumberOfRooms = 5,
                            HotelsId = 2,
                        },
                        new Room()
                        {
                            Name = "Bogato",
                            Description = "Dla bogatych",
                            Price = 88M,
                            NumberOfRooms = 25,
                            HotelsId = 2,
                        }
                        },
                        Address = new Address()
                        {
                            City = "Poznan",
                            Street = "Warszawska",
                            PostalCode = "50-792"
                        }
            }};

            return hotel;
        }
    }
}
