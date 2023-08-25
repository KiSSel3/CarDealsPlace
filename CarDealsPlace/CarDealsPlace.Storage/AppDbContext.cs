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
            base.OnModelCreating(modelBuilder);


            #region Заполнение бд (Временно)
            VehicleModel vehicle = new VehicleModel()
            {
                Id = Guid.NewGuid(),
                Brand = "BMW",
                Model = "M5 f90",
                Mileage = 5,
                EngineDisplacement = 15,
                ProductionYear = new DateTime(2023),
                VehicleType = Domain.Enums.VehicleType.SEDAN,
                WheelDriveType = Domain.Enums.WheelDriveType.ALL,
                TransmissionType = Domain.Enums.TransmissionType.AUTOMATIC,
                ImageUrls = new(),
            };
            //modelBuilder.Entity<VehicleModel>().HasData(vehicle);

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
            //modelBuilder.Entity<UserModel>().HasData(user);

            OfferModel offer = new OfferModel()
            {
                Id = Guid.NewGuid(),
                User = user,
                Vehicle = vehicle,
                PublicationData = DateTime.Now,
                Description = "---",
                Price = 150000.0f,
            };

            modelBuilder.Entity<OfferModel>(o =>
            {
                o.OwnsOne(u => u.User).HasData(user);
                o.OwnsOne(v => v.Vehicle).HasData(vehicle);
                o.HasData(offer);
            });
        #endregion
    }
}
}
