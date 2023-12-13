using Hotelum.Entities;
using Hotelum.Models;
using Hotelum.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Reflection;
using Hotelum.Services;
using NLog.Web;
using Hotelum.Middleware;

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
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<RequestTimeMiddleware>();
            builder.Services.AddSwaggerGen();
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

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
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeMiddleware>();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotelum");
            });
            app.UseRouting();
            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}