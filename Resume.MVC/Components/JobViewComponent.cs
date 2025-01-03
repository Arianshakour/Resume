using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.Job;

namespace Resume.MVC.Components
{
	public class JobViewComponent : ViewComponent
	{
		private readonly IJobService _jobService;

		public JobViewComponent(IJobService jobService)
		{
			_jobService = jobService;
		}
        public async Task<IViewComponentResult> InvokeAsync()
		{
			var x = await _jobService.FilterAsync(new FilterJobViewModel()
			{

			});
			return View("Job",x);
		}

    }
}
