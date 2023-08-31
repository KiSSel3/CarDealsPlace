using CarDealsPlace.Service.Implementations;
using CarDealsPlace.Service.Interfaces;
using CarDealsPlace.Storage;
using CarDealsPlace.Storage.Implementations;
using CarDealsPlace.Storage.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            builder.Services.AddScoped<IOfferService, OfferService>();
        }

        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "Authentication";
                    options.Cookie.HttpOnly = true;
                    options.LoginPath = "/Account/Login";
                    options.SlidingExpiration = true;
                });
        }
        public static void AddDataBase(this WebApplicationBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
