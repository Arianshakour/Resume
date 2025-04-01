using Resume.Bus.Services.Interfaces;
using Resume.DLA.Entities.Job;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Implementation
{
	public class JobService : IJobService
	{
		private readonly IJobRepository _jobRepository;

		public JobService(IJobRepository jobRepository)
		{
			_jobRepository = jobRepository;
		}

		public async Task<CreateJobResult> CreateAsync(CreateJobViewModel model)
		{
			var job = new Job();
			job.Start=model.Start;
			job.End=model.End;
			job.Title=model.Title;
			job.Description=model.Description;
			job.CreateOn=DateTime.Now;
			await _jobRepository.Insert(job);
			await _jobRepository.Save();
			return CreateJobResult.Success;
		}

		public async Task<DeleteJobResult> DeleteAsync(int id)
		{
			var x = await _jobRepository.GetById(id);
			if (x == null)
			{
				return DeleteJobResult.Error;
			}
			_jobRepository.Delete(x);
			await _jobRepository.Save();
			return DeleteJobResult.Success;
		}
		//taqir method be EditAsync2 baraye inke modal render kone
		public async Task<EditJobResult> EditAsync(EditJobViewModel model)
		{
			var x = await _jobRepository.GetById(model.Id);
			if (x == null)
			{
				return EditJobResult.NotFound;
			}
			x.Id = model.Id;
			x.Start = model.Start;
			x.End = model.End;
			x.Title = model.Title;
			x.Description = model.Description;
			_jobRepository.Edit(x);
			await _jobRepository.Save();
			return EditJobResult.Success;
		}

        public async Task<FilterJobViewModel> EditAsync2(EditJobViewModel model)
        {
            var x = await _jobRepository.GetById(model.Id);
            x.Id = model.Id;
            x.Start = model.Start;
            x.End = model.End;
            x.Title = model.Title;
            x.Description = model.Description;
            _jobRepository.Edit(x);
            await _jobRepository.Save();
			var filter = new FilterJobViewModel();
			return await FilterAsync(filter);
        }

        public async Task<FilterJobViewModel> FilterAsync(FilterJobViewModel model)
		{
			return await _jobRepository.FilterAsync(model);
		}

		public async Task<EditJobViewModel> GetInfoById(int id)
		{
			return await _jobRepository.GetInfoById(id);
		}

		public async Task<DeleteJobViewModel> GetJobForDelete(int id)
		{
			return await _jobRepository.GetJobForDelete(id);
		}
	}
}
