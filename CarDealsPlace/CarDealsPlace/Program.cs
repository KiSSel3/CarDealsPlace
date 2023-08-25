using CarDealsPlace;
using CarDealsPlace.Domain.Models;
using CarDealsPlace.Storage;
using CarDealsPlace.Storage.Implementations;
using CarDealsPlace.Storage.Interfaces;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddDataBase();
        builder.AddServices();

        //
        AppDbContext test = builder.Services.BuildServiceProvider().GetRequiredService<AppDbContext>();
        test.Users.ToList();
        var app = builder.Build();
        //

        OfferModel offer = new();
        

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