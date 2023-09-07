using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.Response;
using CarDealsPlace.Domain.ViewModels;
using CarDealsPlace.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarDealsPlace.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService) => (this.userService) = (userService);

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string userLogin = User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (!string.IsNullOrEmpty(userLogin))
            {
                BaseResponse<UserModel> response = await userService.GetByLogn(userLogin);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return View(response.Data);

                return View("Error", new ErrorViewModel() { RequestId = response.Description });
            }

            return View("Error", new ErrorViewModel() { RequestId = "Ошибка авторизации!" });
        }

        [HttpGet]
        public IActionResult Authorization(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                BaseResponse<ClaimsIdentity> response = await userService.Login(model);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("/");
                }

                ModelState.AddModelError("LoginError", response.Description);
            }

            return View("Authorization");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                BaseResponse<ClaimsIdentity> response = await userService.Register(model);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("/");
                }

                ModelState.AddModelError("LoginError", response.Description);
            }

            return View("Authorization");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
                return View("Error", new ErrorViewModel() { RequestId = "Вы не вошли в аккаунт!" });

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
