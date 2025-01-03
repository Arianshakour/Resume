using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Extentions;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.User;

namespace Resume.MVC.Areas.Admin.Controllers
{
	//[Authorize]
	public class UserController : AdminBaseController
	{
		private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> List(FilterUserViewModel filter)
		{
			var result = await _userService.FilterUserAsync(filter);
			return View(result);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateUserViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _userService.CreateUserAsync(model);
			switch (result)
			{
				case CreateUserResult.Success:
					TempData[SuccessMessage] = "با موفقیت انجام شد";
					return RedirectToAction("List");
				case CreateUserResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
				default:
					break;
			}
			return View(model);
		}
		public async Task<IActionResult> Update(int id)
		{
			var user = await _userService.GetUserById(id);
			if (user == null)
			{
				return NotFound();
			}
			return View(user);
		}
		[HttpPost]
		public async Task<IActionResult> Update(EditUserViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _userService.EditUserAsync(model);
			switch (result)
			{
				case EditUserResult.Success:
                    TempData[SuccessMessage] = "با موفقیت انجام شد";
                    return RedirectToAction("List");
                case EditUserResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
				case EditUserResult.DuplicateEmail:
                    TempData[ErrorMessage] = "ایمیل تکراری است";
                    break;
				case EditUserResult.DuplicateMobile:
                    TempData[ErrorMessage] = "موبایل تکراری است";
                    break;
				case EditUserResult.NotFound:
                    TempData[ErrorMessage] = "کاربر پیدا نشد";
                    break;
			}
			return View(model);
		}
    }
}
