using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.AboutMe;

namespace Resume.MVC.Areas.Admin.Controllers
{
    public class AboutMeController : AdminBaseController
    {
        private readonly IAboutMeService _aboutMeService;
        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }
        public async Task<IActionResult> Edit()
        {
            var result = await _aboutMeService.GetInfo();
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AdminEditAboutMeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _aboutMeService.Update(model);
            switch (result)
            {
                case AdminEditAboutMeResult.Success:
                    TempData[SuccessMessage] = "ویرایش با موفقیت انجام شد";
                    return RedirectToAction(nameof(Edit));
                case AdminEditAboutMeResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
                case AdminEditAboutMeResult.NotFound:
                    TempData[ErrorMessage] = "پیدا نشد";
                    break;
            }
            return View(result);
        }
    }
}
