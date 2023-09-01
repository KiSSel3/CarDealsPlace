using CarDealsPlace.Domain.Response;
using CarDealsPlace.Domain.ViewModels;
using CarDealsPlace.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarDealsPlace.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService) => (this.userService) = (userService);

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                BaseResponse<ClaimsIdentity> response = await userService.Login(model);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));

                    string previousPath = Request.Cookies["PreviousPagePath"];
                    if (!string.IsNullOrEmpty(previousPath))
                        return Redirect(previousPath);

                    return Redirect("/");
                }

                ModelState.AddModelError("LoginError", response.Description);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                BaseResponse<ClaimsIdentity> response = await userService.Register(model);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));

                    string previousPath = Request.Cookies["PreviousPagePath"];
                    if (!string.IsNullOrEmpty(previousPath))
                        return Redirect(previousPath);

                    return Redirect("/");
                }

                ModelState.AddModelError("LoginError", response.Description);
            }

            return View("Index");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            string previousPath = Request.Cookies["PreviousPagePath"];
            if (!string.IsNullOrEmpty(previousPath))
                return Redirect(previousPath);

            return Redirect("/");
        }
    }
}
