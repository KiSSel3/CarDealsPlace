using CarDealsPlace;
using CarDealsPlace.Domain.Models;
using CarDealsPlace.Storage;
using CarDealsPlace.Storage.Implementations;
using CarDealsPlace.Storage.Interfaces;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private async static Task Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddDataBase();
        builder.AddServices();

        var app = builder.Build();

        IOfferStorage repos = builder.Services.BuildServiceProvider().GetRequiredService<IOfferStorage>();

        VehicleModel vehicle = new VehicleModel()
        {
            Id = Guid.NewGuid(),
            Brand = "BMW",
            Model = "M5 f90",
            Mileage = 5,
            EngineDisplacement = 15,
            ProductionYear = new DateTime(2023),
            VehicleType = CarDealsPlace.Domain.Enums.VehicleType.SEDAN,
            WheelDriveType = CarDealsPlace.Domain.Enums.WheelDriveType.ALL,
            TransmissionType = CarDealsPlace.Domain.Enums.TransmissionType.AUTOMATIC,
            ImageUrls = new(),
        };

        UserModel user = new UserModel()
        {
            Id = Guid.NewGuid(),
            Login = "kissel",
            Password = "kissel",
            Email = "---",
            Name = "Andrey",
            PhoneNumber = "---",
            ImageUrl = "---",
        };

        OfferModel offer = new OfferModel()
        {
            Id = Guid.NewGuid(),
            User = user,
            Vehicle = vehicle,
            PublicationData = DateTime.Now,
            Description = "---",
            Price = 150000.0f,
        };

        await repos.CreateAsync(offer);
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}