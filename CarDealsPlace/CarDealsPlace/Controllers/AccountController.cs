using Microsoft.AspNetCore.Mvc;

namespace CarDealsPlace.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
