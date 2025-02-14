using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Resume.Bus.Extentions;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.Entities.User;
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
			return PartialView("Create");
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateJobViewModel model)
		{
            if (!ModelState.IsValid)
            {
				string v1 = ViewRendererUtils.RenderRazorViewToString(this, "~/Areas/Admin/Views/Job/Create.cshtml", model);
                return Json(new { view = v1, isGrid = 0 });
            }
            await _jobService.CreateAsync(model);
            // chon mikhaim safe list ra render konim in method ma khorojish createresult hast pas
			//be dard nemikhore ma bayad filter ra pas bdim injoori
			//mitooni baraye tamizi method create ra taqir bdi ke filterviewmodel bargardoone
            FilterJobViewModel filterModel = new FilterJobViewModel();
            filterModel = await _jobService.FilterAsync(filterModel);
            string v2 = ViewRendererUtils.RenderRazorViewToString(this, "~/Areas/Admin/Views/Job/_gridJob.cshtml", filterModel);
            return Json(new { view = v2, isGrid = 1 });
        }
		public async Task<IActionResult> Edit(int id)
		{
			var result = await _jobService.GetInfoById(id);
			if (result == null)
			{
				return NotFound();
			}
            return PartialView("Edit", result);
        }
        [HttpPost]
		public async Task<IActionResult> Edit(EditJobViewModel model)
		{
			if (!ModelState.IsValid)
			{
                string v1 = ViewRendererUtils.RenderRazorViewToString(this, "~/Areas/Admin/Views/Job/Edit.cshtml", model);
                return Json(new { view = v1, isGrid = 0 });
            }
			var result = await _jobService.EditAsync2(model);
            string v2 = ViewRendererUtils.RenderRazorViewToString(this, "~/Areas/Admin/Views/Job/_gridJob.cshtml", result);
            return Json(new { view = v2, isGrid = 1 });
        }
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _jobService.GetJobForDelete(id);
			if(result== null)
			{
				return NotFound();
			}
			return PartialView("Delete", result);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteConfirm(int id)
		{
			await _jobService.DeleteAsync(id);
            FilterJobViewModel filterModel = new FilterJobViewModel();
            filterModel = await _jobService.FilterAsync(filterModel);
            return PartialView("~/Areas/Admin/Views/Job/_gridJob.cshtml", filterModel);
		}
	}
}
