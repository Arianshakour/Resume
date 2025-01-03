using Microsoft.EntityFrameworkCore;
using Resume.DLA.Context;
using Resume.DLA.Entities.Job;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Implementation
{
	public class JobRepository : IJobRepository
	{
		private readonly ResumeContext _context;

		public JobRepository(ResumeContext context)
		{
			_context = context;
		}

		public void Delete(Job job)
		{
			_context.Jobs.Remove(job);
		}

		public void Edit(Job job)
		{
			_context.Jobs.Update(job);
		}

		public async Task<FilterJobViewModel> FilterAsync(FilterJobViewModel model)
		{
			var query = _context.Jobs.AsQueryable();
			if(!string.IsNullOrEmpty(model.Title))
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}
			if (model.Start.HasValue)
			{
				query = query.Where(x=>x.Start>=model.Start);
			}
			if (model.End.HasValue)
			{
				query = query.Where(x=>x.End<=model.End);
			}
			await model.Paging(query.Select(x => new DetailJobViewModel()
			{
				End = x.End,
				Start = x.Start,
				Title = x.Title,
				Id = x.Id,
				Description = x.Description,
				CreateOn = x.CreateOn
			}));
			return model;
		}

		public async Task<Job?> GetById(int id)
		{
			return await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<EditJobViewModel> GetInfoById(int id)
		{
			var x = await _context.Jobs.FirstOrDefaultAsync(y => y.Id == id);
			return new EditJobViewModel()
			{
				Id = x.Id,
				Title = x.Title,
				Description	= x.Description,
				Start = x.Start,
				End = x.End
			};
		}
		public async Task<DeleteJobViewModel> GetJobForDelete(int id)
		{
			var x = await _context.Jobs.FirstOrDefaultAsync(t=>t.Id == id);
			return new DeleteJobViewModel()
			{
				Id = x.Id,
				Title = x.Title
			};
		}

		public async Task Insert(Job job)
		{
			await _context.Jobs.AddAsync(job);
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
	}
}
