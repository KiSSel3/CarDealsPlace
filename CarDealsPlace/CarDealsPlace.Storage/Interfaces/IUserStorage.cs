using CarDealsPlace.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Storage.Interfaces
{
    public interface IUserStorage : IBaseStorage<UserModel>
    {
        public Task<UserModel> GetByLoginAsync(string login);
        public Task<UserModel> GetByPhoneNumberAsync(string phoneNumber);
        public Task<UserModel> GetByEmailAsync(string email);
    }
}
