using CarDealsPlace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealsPlace.Storage
{
    public class AppDbContext : DbContext
    {
        public DbSet<OfferModel> Offers { get; set; } = null!;
        public DbSet<UserModel> Users { get; set; } = null!;
        public DbSet<VehicleModel> Vehicles { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FIXME: Если возникла проблема с удалением объекта в бд, ошибка тут
            modelBuilder.Entity<OfferModel>()
                .HasOne<UserModel>(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);//Тут

            modelBuilder.Entity<OfferModel>()
                .HasOne<VehicleModel>(o => o.Vehicle)
                .WithMany()
                .HasForeignKey(o => o.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);//Тут
        }
    }
}
