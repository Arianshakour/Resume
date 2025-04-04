using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Resume.Bus.Extentions;
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
                //return View(model);
                string v1 = ViewRendererUtils.RenderRazorViewToString(this, "~/Views/ContactUs/ContactUs.cshtml", model);
                return Json(new { view = v1, success = false });
            }
            var result = await _contactUsService.CreateAsync(model);
            switch (result)
            {
                case CreateContactUsResult.Success:
                    TempData[SuccessMessage] = "پیام ثبت شد نتیجه با ایمیل پاسخ داده میشود";
                    string v2 = ViewRendererUtils.RenderRazorViewToString(this, "~/Views/ContactUs/ContactUs.cshtml");
                    return Json(new { view = v2, success = true });
                    //return RedirectToAction("ContactUs");
                case CreateContactUsResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده";
                    break;
            }
            //return View(model);
            string v3 = ViewRendererUtils.RenderRazorViewToString(this, "~/Views/ContactUs/ContactUs.cshtml", model);
            return Json(new { view = v3, success = false });
        }
    }
}
