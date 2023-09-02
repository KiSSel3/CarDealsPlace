using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.Response;
using CarDealsPlace.Filters;
using CarDealsPlace.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDealsPlace.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService) => (this.offerService) = (offerService);

        public async Task<IActionResult> Index()
        {
            BaseResponse<IEnumerable<OfferModel>> response = await offerService.GetAllOffers();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            BaseResponse<OfferModel> response = await offerService.GetOfferById(id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Error");
        }
    }
}
