using Hotelum.Entities;
using Hotelum.Models;
using Hotelum.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Hotelum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<HotelsDbContext>();
            builder.Services.AddScoped<HotelsSeeder>();
            builder.Services.AddAutoMapper(typeof(Hotels).Assembly);


            var app = builder.Build();



            // Configure the HTTP request pipeline.

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var seeder = services.GetRequiredService<HotelsSeeder>();
                    seeder.Seed();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions while seeding
                    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                }
            }
            
            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}