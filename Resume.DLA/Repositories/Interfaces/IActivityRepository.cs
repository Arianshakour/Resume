using Resume.DLA.Entities.Activity;
using Resume.DLA.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Interfaces
{
	public interface IActivityRepository
	{
		Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);
		Task Insert(Activity activity);
		void Update(Activity activity);
		Task Save();
		Task<EditActivityViewModel> GetInfoById(int id);
        Task<Activity?> GetById(int id);
        Task<List<DetailsActivityViewModel>> GetAll();
    }
}
