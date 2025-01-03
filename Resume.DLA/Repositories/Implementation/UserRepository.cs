using Microsoft.EntityFrameworkCore;
using Resume.DLA.Context;
using Resume.DLA.Entities.User;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Implementation
{
	public class UserRepository : IUserRepository
	{
		private readonly ResumeContext _context;
        public UserRepository(ResumeContext context)
        {
			_context=context;
		}
		public async Task InsertAsync(User user)
		{
			await _context.Users.AddAsync(user);
		}
		public async Task<User> GetById(int id)
		{
			return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
		}
		public void Update(User user)
		{
			_context.Users.Update(user);
		}
		public async Task<bool> DuplicateEmail(int id, string email)
		{
			return await _context.Users.AnyAsync(x=>x.Email == email && x.Id != id);
		}

		public async Task<bool> DuplicateMobile(int id, string mobile)
		{
			return await _context.Users.AnyAsync(x => x.Mobile == mobile && x.Id != id);
		}
		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
		public async Task<FilterUserViewModel> FilterUserAsync(FilterUserViewModel model)
		{
			var query = _context.Users.AsQueryable();
			if(!string.IsNullOrEmpty(model.Email))
			{
				//query = query.Where(x=>x.Email==model.Email);
				query = query.Where(x=>EF.Functions.Like(x.Email,$"%{model.Email}%"));
            }
			if (!string.IsNullOrEmpty(model.Mobile))
			{
                //query = query.Where(x => x.Mobile == model.Mobile);
                query = query.Where(x => EF.Functions.Like(x.Mobile, $"%{model.Mobile}%"));

            }
            await model.Paging(query.Select(x => new UserDetailsViewModel()
			{
				Id = x.Id,
				LastName = x.LastName,
				FirstName = x.FirstName,
				Email = x.Email,
				IsActive = x.IsActive,
				RegDate = x.RegDate,
				Mobile = x.Mobile,
			}));
			return model;
		}
        public async Task<User> GetByEmail(string email)
		{
			return _context.Users.FirstOrDefault(x => x.Email == email);
		}


    }
}
