using Hotelum.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<HotelsDbContext>();
            builder.Services.AddScoped<HotelsSeeder>();


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