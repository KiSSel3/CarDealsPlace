using CarDealsPlace.Domain.Models;
using CarDealsPlace.Models;
using CarDealsPlace.Storage.Implementations;
using CarDealsPlace.Storage.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

#region Для изучения технологии(Временно)

#endregion

namespace CarDealsPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOfferStorage _offerStorage;

        public HomeController(ILogger<HomeController> logger, IOfferStorage offerStorage)
        {
            _logger = logger;
            _offerStorage = offerStorage;
        }

        public async Task<IActionResult> Privacy()
        {
            #region Для изучения технологии(Временно)
            OfferModel? offer = (await _offerStorage.GetAllAsync()).ElementAtOrDefault(0);
            #endregion

            return View(offer);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}