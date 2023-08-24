using CarDealsPlace.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
