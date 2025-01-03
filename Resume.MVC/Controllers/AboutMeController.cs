using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;

namespace Resume.MVC.Controllers
{
    public class AboutMeController : SiteBaseController
    {
        private readonly IAboutMeService _aboutMeService;
        public AboutMeController(IAboutMeService aboutMeService)
        {
			_aboutMeService = aboutMeService;
		}
        [HttpGet("/About-me")]
        public async Task<IActionResult> Index()
        {
            var model = await _aboutMeService.GetClientInfo();
            return View(model);
        }
    }
}
