using Resume.DLA.Entities.User;
using Resume.DLA.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task InsertAsync(User user);
		Task SaveAsync();
		Task<User> GetById(int id);
		Task<User> GetByEmail(string email);
		void Update(User user);
		Task<bool> DuplicateMobile(int id , string mobile);
		Task<bool> DuplicateEmail(int id , string email);
		Task<FilterUserViewModel> FilterUserAsync(FilterUserViewModel model);

	}
}
