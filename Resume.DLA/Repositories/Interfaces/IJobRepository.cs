using Resume.DLA.Entities.Job;
using Resume.DLA.Migrations;
using Resume.DLA.ViewModels.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Interfaces
{
	public interface IJobRepository
	{
		Task<Job?> GetById(int id);
		void Edit(Job job);
		Task Insert(Job job);
		Task Save();
		void Delete(Job job);
		Task<FilterJobViewModel> FilterAsync(FilterJobViewModel model);
		Task<EditJobViewModel> GetInfoById(int id);
		Task<DeleteJobViewModel> GetJobForDelete(int id);
	}
}
