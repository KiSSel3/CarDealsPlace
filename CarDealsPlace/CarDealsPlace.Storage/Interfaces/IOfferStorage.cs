using CarDealsPlace.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Storage.Interfaces
{
    public interface IOfferStorage : IBaseStorage<OfferModel>
    {
        public Task<IEnumerable<OfferModel>> GetByUserAsync(UserModel user);
        public Task<IEnumerable<OfferModel>> GetByUserLoginAsync(string login);
    }
}
