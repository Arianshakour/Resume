using Microsoft.EntityFrameworkCore;
using Resume.DLA.Context;
using Resume.DLA.Entities.Activity;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Implementation
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly ResumeContext _context;

		public ActivityRepository(ResumeContext context)
		{
			_context = context;
		}
		public async Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
		{
			var query = _context.Activities.OrderByDescending(x=>x.CreateOn).AsQueryable();
			if(!string.IsNullOrEmpty(model.Title))
			{
				query = query.Where(x => EF.Functions.Like(x.Title, $"%{model.Title}%"));
			}
			await model.Paging(query.Select(o => new DetailsActivityViewModel()
			{
				Id= o.Id,
				Title= o.Title,
				CreateOn=o.CreateOn,
				Description = o.Description,
				Icon = o.Icon
			}));
			return model;
		}
        public async Task Insert(Activity activity)
		{
			await _context.Activities.AddAsync(activity);
		}
        public void Update(Activity activity)
		{
			_context.Activities.Update(activity);
		}
        public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
        public async Task<EditActivityViewModel> GetInfoById(int id)
		{
			var act = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
			return new EditActivityViewModel()
			{
				Title = act.Title,
				Icon = act.Icon,
				Id = act.Id,
				Description = act.Description
			};
		}
        public async Task<Activity?> GetById(int id)
		{
			return await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
		}
        public async Task<List<DetailsActivityViewModel>> GetAll()
		{
			return await _context.Activities.
				Select(x => new DetailsActivityViewModel()
				{
					Title = x.Title,
					Icon = x.Icon,
					Id = x.Id,
					Description = x.Description,
					CreateOn = x.CreateOn,
				}).ToListAsync();
        }
    }
}
