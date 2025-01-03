using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.Activity;
using Resume.DLA.ViewModels.ContactUs;

namespace Resume.MVC.Areas.Admin.Controllers
{
	public class ActivityController : AdminBaseController
	{
		private readonly IActivityService _activityService;

		public ActivityController(IActivityService activityService)
		{
			_activityService = activityService;
		}

		public async Task<IActionResult> List(FilterActivityViewModel filter)
		{
			var result = await _activityService.FilterAsync(filter);
			return View(result);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> Create(CreateActivityViewModel model)
        {
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _activityService.CreateAsync(model);
            switch (result)
            {
                case CreateActivityResult.Success:
                    TempData[SuccessMessage] = "با موفقیت اضافه شد";
                    return RedirectToAction("List");
                case CreateActivityResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var x = await _activityService.GetInfoById(id);
            if (x == null)
            {
                return NotFound();
            }
            return View(x);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditActivityViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _activityService.EditAsync(model);
            switch (result)
            {
                case EditActivityResult.Success:
                    TempData[SuccessMessage] = "با موفقیت ویرایش شد";
                    return RedirectToAction("List");
                case EditActivityResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
                case EditActivityResult.NotFound:
                    TempData[ErrorMessage] = "پیدا نشد";
                    break;
            }
            return View(model);
        }
    }
}
