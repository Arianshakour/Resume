using Resume.Bus.Services.Interfaces;
using Resume.DLA.Entities.Activity;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Implementation
{
	public class ActivityService : IActivityService
	{
		private readonly IActivityRepository _activityRepository;

		public ActivityService(IActivityRepository activityRepository)
		{
			_activityRepository = activityRepository;
		}
		public async Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
		{
			return await _activityRepository.FilterAsync(model);
		}
        public async Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model)
		{
			Activity activity = new Activity()
			{
				CreateOn=DateTime.Now,
				Icon = model.Icon,
				Title = model.Title,
				Description = model.Description
			};
			await _activityRepository.Insert(activity);
			await _activityRepository.Save();
			return CreateActivityResult.Success;
		}
        public async Task<EditActivityResult> EditAsync(EditActivityViewModel model)
		{
			var act = await _activityRepository.GetById(model.Id);
			if(act == null)
			{
				return EditActivityResult.NotFound;
			}
			act.Title = model.Title;
			act.Icon = model.Icon;
			act.Description = model.Description;
			_activityRepository.Update(act);
			await _activityRepository.Save();
			return EditActivityResult.Success;
		}
        public async Task<EditActivityViewModel> GetInfoById(int id)
		{
			return await _activityRepository.GetInfoById(id);
		}
		public async Task<List<DetailsActivityViewModel>> GetAll()
		{
			return await _activityRepository.GetAll();
		}
    }
}
