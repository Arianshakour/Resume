using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.Education;

namespace Resume.MVC.Components
{
    public class EducationViewComponent : ViewComponent
    {
        private readonly IEducationService _educationService;

        public EducationViewComponent(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _educationService.FilterAsync(new FilterEducationViewModel
            {

            });
            return View("Education", model);
        }
    }
}
