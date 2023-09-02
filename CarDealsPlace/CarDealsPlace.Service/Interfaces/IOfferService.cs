using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Service.Interfaces
{
    public interface IOfferService
    {
        public Task<BaseResponse<IEnumerable<OfferModel>>> GetAllOffers();
        public Task<BaseResponse<OfferModel>> GetOfferById(Guid id);
    }
}
