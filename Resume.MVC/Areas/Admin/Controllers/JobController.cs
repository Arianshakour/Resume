using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.ViewModels.Education;
using Resume.DLA.ViewModels.Job;

namespace Resume.MVC.Areas.Admin.Controllers
{
	public class JobController : AdminBaseController
	{
		private readonly IJobService _jobService;

		public JobController(IJobService jobService)
		{
			_jobService = jobService;
		}
		public async Task<IActionResult> List(FilterJobViewModel filter)
		{
			var result = await _jobService.FilterAsync(filter);
			return View(result);
		}
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateJobViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _jobService.CreateAsync(model);
			switch (result)
			{
				case CreateJobResult.Success:
					TempData[SuccessMessage] = "با موفقیت انجام شد";
					return RedirectToAction("List");
				case CreateJobResult.Error:
					TempData[ErrorMessage] = "خطایی رخ داده";
					break;
			}
			return View(model);
		}
		public async Task<IActionResult> Edit(int id)
		{
			var result = await _jobService.GetInfoById(id);
			if (result == null)
			{
				return NotFound();
			}
			return View(result);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(EditJobViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _jobService.EditAsync(model);
			switch (result)
			{
				case EditJobResult.Success:
					TempData[SuccessMessage] = "با موفقیت انجام شد";
					return RedirectToAction("List");
				case EditJobResult.Error:
					TempData[ErrorMessage] = "خطایی رخ داده";
					break;
				case EditJobResult.NotFound:
					TempData[ErrorMessage] = "پیدا نشد";
					break;
			}
			return View(model);
		}
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _jobService.GetJobForDelete(id);
			if(result== null)
			{
				return NotFound();
			}
			return View(result);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteConfirm(DeleteJobViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _jobService.DeleteAsync(model);
			switch (result)
			{
				case DeleteJobResult.Success:
					TempData[SuccessMessage] = "با موفقیت انجام شد";
					return RedirectToAction("List");
				case DeleteJobResult.Error:
					TempData[ErrorMessage] = "خطایی رخ داده";
					break;
			}
			return View(model);
		}
	}
}
