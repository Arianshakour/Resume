using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.ContactUs;
using Resume.DLA.ViewModels.Education;

namespace Resume.MVC.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public async Task<IActionResult> List(FilterEducationViewModel filter)
        {
            var model = await _educationService.FilterAsync(filter);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _educationService.CreateAsync(model);
            switch (result)
            {
                case CreateEducationResult.Success:
                    TempData[SuccessMessage] = "با موفقیت انجام شد";
                    return RedirectToAction("List");
                case CreateEducationResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
            }
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var x = await _educationService.GetInfoById(id);
            if (x == null)
            {
                return NotFound();
            }
            return View(x);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _educationService.EditAsync(model);
            switch (result)
            {
                case EditEducationResult.Success:
                    TempData[SuccessMessage] = "با موفقیت انجام شد";
                    return RedirectToAction("List");
                case EditEducationResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
                case EditEducationResult.NotFound:
                    TempData[ErrorMessage] = "پیدا نشد";
                    break;
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _educationService.GetIdForDelete(id);
            if (x == null)
            {
                return NotFound();
            }
            return View(x);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(DeleteEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Delete", model);
            }
            var result = await _educationService.DeleteAsync(model);
            switch (result)
            {
                case DeleteEducationResult.Success:
                    TempData[SuccessMessage] = "با موفقیت انجام شد";
                    return RedirectToAction("List");
                case DeleteEducationResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
            }
            return View("Delete", model);
        }
    }
}
