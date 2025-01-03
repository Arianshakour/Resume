using Resume.DLA.Entities.Activity;
using Resume.DLA.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Interfaces
{
	public interface IActivityService
	{
		Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);
		Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model);
		Task<EditActivityResult> EditAsync(EditActivityViewModel model);
		Task <EditActivityViewModel> GetInfoById(int id);
		Task<List<DetailsActivityViewModel>> GetAll();
	}
}
