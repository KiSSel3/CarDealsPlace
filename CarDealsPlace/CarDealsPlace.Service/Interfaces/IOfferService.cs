using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.Response;
using CarDealsPlace.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Service.Interfaces
{
    public interface IOfferService
    {
        public Task<BaseResponse<OfferModel>> Create(OfferViewModel offerViewModel, string login);
        public Task<BaseResponse<IEnumerable<OfferModel>>> GetAllOffers();
        public Task<BaseResponse<OfferModel>> GetOfferById(Guid id);
        public Task<BaseResponse<IEnumerable<OfferModel>>> GetOffersByUserLogin(string login);
    }
}
