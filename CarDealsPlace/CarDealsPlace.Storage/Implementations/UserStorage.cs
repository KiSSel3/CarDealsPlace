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
    public class UserStorage : IUserStorage
    {
        private readonly AppDbContext db;

        public UserStorage(AppDbContext db) => this.db = db;

        public async Task CreateAsync(UserModel item)
        {
            await db.Users.AddAsync(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserModel item)
        {
            db.Users.Remove(item);
            await db.SaveChangesAsync();
        }   

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            return db.Users.FirstOrDefault(user => user.Id == id, null);
        }

        public async Task<UserModel> GetByLoginAsync(string login)
        {
            return db.Users.FirstOrDefault(user => user.Login == login, null);
        }

        public async Task<UserModel> UpdateAsync(UserModel item)
        {
            db.Users.Update(item);
            await db.SaveChangesAsync();

            return item;
        }
    }
}
