using Resume.DLA.Entities.User;
using Resume.DLA.ViewModels.Account;
using Resume.DLA.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Interfaces
{
	public interface IUserService
	{
		Task<CreateUserResult> CreateUserAsync(CreateUserViewModel model);
		Task<EditUserViewModel> GetUserById(int id);
		Task<EditUserResult> EditUserAsync(EditUserViewModel model);
		Task<FilterUserViewModel> FilterUserAsync(FilterUserViewModel model);
		Task<LoginResult> LoginUserAsync(LoginViewModel model);
		Task<User> GetUserByEmail(string email);
		Task<UserDetailsViewModel> GetInformation(int id);
	}
}
