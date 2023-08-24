using CarDealsPlace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealsPlace.Storage
{
    public class AppDbContext : DbContext
    {
        DbSet<OfferModel> Offers { get; set; } = null!;
        DbSet<UserModel> Users { get; set; } = null!;
        DbSet<VehicleModel> Vehicles { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //FIXME: каскадное удаление в бд может быть настроено некорректно
            modelBuilder.Entity<OfferModel>()
                .HasOne(o => o.Vehicle)
                .WithMany()
                .HasForeignKey(o => o.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OfferModel>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
