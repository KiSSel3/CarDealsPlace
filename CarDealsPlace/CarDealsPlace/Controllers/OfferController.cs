using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.Response;
using CarDealsPlace.Domain.ViewModels;
using CarDealsPlace.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

            return View("Error", new ErrorViewModel() { RequestId = response.Description });
        }

        public async Task<IActionResult> Details(Guid id)
        {
            BaseResponse<OfferModel> response = await offerService.GetOfferById(id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return View(response.Data);

            return View("Error", new ErrorViewModel() { RequestId = response.Description });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserOffers()
        {
            string userLogin = User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (!string.IsNullOrEmpty(userLogin))
            {
                BaseResponse<IEnumerable<OfferModel>> response = await offerService.GetOffersByUserLogin(userLogin);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return View(response.Data);

                return View("Error", new ErrorViewModel() { RequestId = response.Description });
            }

            return View("Error", new ErrorViewModel() { RequestId = "Ошибка авторизации!" });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreateOffer()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOffer(OfferViewModel offerViewModel)
        {
            if (ModelState.IsValid)
            {
                string userLogin = User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
                if (!string.IsNullOrEmpty(userLogin))
                {
                    BaseResponse<OfferModel> response = await offerService.Create(offerViewModel, userLogin);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return RedirectToAction("UserOffers");

                    return View("Error", new ErrorViewModel() { RequestId = response.Description });
                }

                return View("Error", new ErrorViewModel() { RequestId = "Ошибка авторизации!" });
            }

            return View();
        }
    }
}
