using CarDealsPlace.Domain.Models;
using CarDealsPlace.Storage.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Storage.Implementations
{
    public class OfferStorage : IOfferStorage
    {
        private readonly AppDbContext db;

        public OfferStorage(AppDbContext db) => this.db = db;

        public async Task CreateAsync(OfferModel item)
        {
            await db.Offers.AddAsync(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(OfferModel item)
        {
            db.Offers.Remove(item);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<OfferModel>> GetAllAsync()
        {
            return await db.Offers.ToListAsync();
        }

        public async Task<OfferModel> GetByIdAsync(Guid id)
        {
            return db.Offers.FirstOrDefault(offer => offer.Id == id, null);
        }

        public async Task<IEnumerable<OfferModel>> GetByUserAsync(UserModel user)
        {
            return db.Offers.Where(offer => offer.UserId == user.Id);
        }

        public async Task<OfferModel> UpdateAsync(OfferModel item)
        {
            db.Offers.Update(item);
            await db.SaveChangesAsync();

            return item;
        }
    }
}
