using CarDealsPlace.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealsPlace.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {


                string previousPath = Request.Cookies["PreviousPagePath"];
                if (!string.IsNullOrEmpty(previousPath))
                    return Redirect(previousPath);

                return Redirect("/");
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {


                string previousPath = Request.Cookies["PreviousPagePath"];
                if (!string.IsNullOrEmpty(previousPath))
                    return Redirect(previousPath);

                return Redirect("/");
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
