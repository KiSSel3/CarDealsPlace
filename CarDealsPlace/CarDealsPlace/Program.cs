using CarDealsPlace;
using CarDealsPlace.Domain.Models;
using CarDealsPlace.Storage.Interfaces;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private async static Task Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddDataBase();
        builder.AddServices();
        builder.AddAuthentication();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}