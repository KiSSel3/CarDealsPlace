using CarDealsPlace.Storage;
using CarDealsPlace.Storage.Implementations;
using CarDealsPlace.Storage.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarDealsPlace
{
    public static class BuilderExtension
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserStorage, UserStorage>();
            builder.Services.AddScoped<IOfferStorage, OfferStorage>();
        }

        public static void AddDataBase(this WebApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
