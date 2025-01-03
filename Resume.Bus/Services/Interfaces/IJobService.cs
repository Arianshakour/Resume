using Resume.DLA.ViewModels.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Interfaces
{
	public interface IJobService
	{
		Task<FilterJobViewModel> FilterAsync(FilterJobViewModel model);
		Task<CreateJobResult> CreateAsync(CreateJobViewModel model);
		Task<EditJobResult> EditAsync(EditJobViewModel model);
		Task<EditJobViewModel> GetInfoById(int id);
		Task<DeleteJobResult> DeleteAsync(DeleteJobViewModel model);
		Task<DeleteJobViewModel> GetJobForDelete(int id);
	}
}
