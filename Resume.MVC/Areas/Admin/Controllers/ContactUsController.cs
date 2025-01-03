using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.ContactUs;

namespace Resume.MVC.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        public async Task<IActionResult> List(FilterContactUsViewModel filter)
        {
            var model = await _contactUsService.FilterContactAsync(filter);
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await _contactUsService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
		public async Task<IActionResult> Details(DetailsContactUsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _contactUsService.AnswerAsync(model);
            switch (result)
            {
				case DetailResult.Success:
					TempData[SuccessMessage] = "پاسخ ارسال شد";
					return RedirectToAction("List");
				case DetailResult.Error:
					TempData[ErrorMessage] = "خطایی رخ داده";
					break;
				case DetailResult.NotFound:
					TempData[ErrorMessage] = "پیدا نشد";
					break;
			}
            return View(model);
        }

	}
}
