using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.ContactUs;
using Resume.DLA.ViewModels.User;

namespace Resume.MVC.Controllers
{
    public class ContactUsController : SiteBaseController
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService= contactUsService;
        }
        [HttpGet("/contact-us")]
        public IActionResult ContactUs()
        {
            return View("ContactUs");
        }
        [HttpPost("/contact-us")]
        public async Task<IActionResult> ContactUs(CreateContactUsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _contactUsService.CreateAsync(model);
            switch (result)
            {
                case CreateContactUsResult.Success:
                    TempData[SuccessMessage] = "پیام ثبت شد نتیجه با ایمیل پاسخ داده میشود";
                    return RedirectToAction("ContactUs");
                case CreateContactUsResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
            }
            return View(model);
        }
    }
}
