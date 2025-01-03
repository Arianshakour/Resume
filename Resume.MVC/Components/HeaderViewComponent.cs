using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;

namespace Resume.MVC.Components
{
	public class HeaderViewComponent : ViewComponent
	{
		private readonly IAboutMeService _aboutMeService;
        public HeaderViewComponent(IAboutMeService aboutMeService)
        {
			_aboutMeService = aboutMeService;

		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _aboutMeService.GetClientInfo();
			return View("Header",model);
		}
    }
}
