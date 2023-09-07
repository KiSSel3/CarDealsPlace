using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.Response;
using CarDealsPlace.Service.Interfaces;
using CarDealsPlace.Storage.Interfaces;

using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealsPlace.Domain.ViewModels;

namespace CarDealsPlace.Service.Implementations
{
    public class OfferService : IOfferService
    {
        private readonly IOfferStorage offerStorage;
        private readonly IUserStorage userStorage;

        public OfferService(IOfferStorage offerStorage, IUserStorage userStorage) => (this.offerStorage, this.userStorage) = (offerStorage, userStorage);

        public async Task<BaseResponse<OfferModel>> Create(OfferViewModel offerViewModel, string login)
        {
            try
            {
                VehicleModel vehicleModel = new VehicleModel(offerViewModel.Brand, offerViewModel.Model, offerViewModel.Mileage, offerViewModel.EngineDisplacement,
                    offerViewModel.Horsepower, offerViewModel.VehicleType, offerViewModel.WheelDriveType, offerViewModel.TransmissionType,
                    offerViewModel.ProductionYear, new List<string>() { ServiceConstants.StandardCarUrl});

                UserModel userModel = await userStorage.GetByLoginAsync(login);

                OfferModel offerModel = new OfferModel(vehicleModel, userModel, offerViewModel.Description, offerViewModel.Price, offerViewModel.Location);

                await offerStorage.CreateAsync(offerModel);

                return new BaseResponse<OfferModel>(HttpStatusCode.OK, offerModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse<OfferModel>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<BaseResponse<IEnumerable<OfferModel>>> GetAllOffers()
        {
            try
            {
                var offers = await offerStorage.GetAllAsync();

                return new BaseResponse<IEnumerable<OfferModel>>(HttpStatusCode.OK, offers);
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OfferModel>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<BaseResponse<OfferModel>> GetOfferById(Guid id)
        {
            try
            {
                var offer = await offerStorage.GetByIdAsync(id);

                return new BaseResponse<OfferModel>(HttpStatusCode.OK, offer);
            }
            catch (Exception ex)
            {
                return new BaseResponse<OfferModel>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<BaseResponse<IEnumerable<OfferModel>>> GetOffersByUserLogin(string login)
        {
            try
            {
                var offers = await offerStorage.GetByUserLoginAsync(login);

                return new BaseResponse<IEnumerable<OfferModel>>(HttpStatusCode.OK, offers);
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OfferModel>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
