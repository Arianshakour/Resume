using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.Account;
using System.Security.Claims;

namespace Resume.MVC.Controllers
{

    public class AccountController : SiteBaseController
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("/login")]
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }
            var result = await _userService.LoginUserAsync(login);
            switch (result)
            {
                case LoginResult.Success:
                    var user = await _userService.GetUserByEmail(login.Email);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.MobilePhone, user.Mobile)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(principal, properties);
                    TempData[SuccessMessage] = "khosh amadid خوش امدید";
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                case LoginResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    return View(login);
                case LoginResult.UserNotFound:
                    ModelState.AddModelError("Password", "کاربری با مشخصات یافت شده پیدا نشد");
                    //TempData[ErrorMessage] = "کاربر یافت نشد";
                    return View(login);
            };
            return View(login);
        }
        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
