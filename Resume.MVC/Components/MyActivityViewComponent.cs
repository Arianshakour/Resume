using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resume.Bus.Services.Interfaces;

namespace Resume.MVC.Components
{
    public class MyActivityViewComponent : ViewComponent
    {
        private readonly IActivityService _activityService;

        public MyActivityViewComponent(IActivityService activityService)
        {
            _activityService = activityService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _activityService.GetAll();
            return View("MyActivity" , result);
        }
    }
}
