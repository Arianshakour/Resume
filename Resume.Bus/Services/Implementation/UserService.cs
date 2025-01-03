using Resume.Bus.Services.Interfaces;
using Resume.Bussines.Security;
using Resume.DLA.Entities.User;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.Account;
using Resume.DLA.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Implementation
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CreateUserResult> CreateUserAsync(CreateUserViewModel model)
		{
			User user = new User()
			{
				Email = model.Email.Trim().ToLower(),
				FirstName = model.FirstName,
				LastName = model.LastName,
				Mobile = model.Mobile,
				IsActive = model.IsActive,
				Password = model.Password.ToLower().EncodePasswordMd5(),
				RePassword = model.RePassword.ToLower().EncodePasswordMd5(),
				RegDate=DateTime.Now
			};
			await _userRepository.InsertAsync(user);
			await _userRepository.SaveAsync();
			return CreateUserResult.Success;
		}

		public async Task<EditUserViewModel> GetUserById(int id)
		{
			var user = await _userRepository.GetById(id);
			if (user == null)
			{
				return null;
			}
			return new EditUserViewModel
			{
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Mobile = user.Mobile,
				IsActive = user.IsActive,
				Id = user.Id
			};
		}
		public async Task<EditUserResult> EditUserAsync(EditUserViewModel model)
		{
			var user = await _userRepository.GetById(model.Id);
			if (user == null)
			{
				return EditUserResult.NotFound;
			}
			if(await _userRepository.DuplicateEmail(user.Id, model.Email.Trim().ToLower()))
			{
				return EditUserResult.DuplicateEmail;
			}
			if (await _userRepository.DuplicateEmail(user.Id, model.Mobile))
			{
				return EditUserResult.DuplicateMobile;
			}
			user.FirstName= model.FirstName;
			user.LastName= model.LastName;
			user.Mobile= model.Mobile;
			user.IsActive= model.IsActive;
			user.Email= model.Email;

			_userRepository.Update(user);
			await _userRepository.SaveAsync();
			return EditUserResult.Success;
		}
		public async Task<FilterUserViewModel> FilterUserAsync(FilterUserViewModel model)
		{
			return await _userRepository.FilterUserAsync(model);
		}
		public async Task<LoginResult> LoginUserAsync(LoginViewModel model)
		{
			model.Email= model.Email.Trim().ToLower();
			var user = await _userRepository.GetByEmail(model.Email);
			if(user == null)
			{
				return LoginResult.UserNotFound;
			}
			string hashpassword = model.Password.ToLower().EncodePasswordMd5();
			if (user.Password != hashpassword)
			{
				return LoginResult.UserNotFound;
			}
			return LoginResult.Success;
        }
        public async Task<User> GetUserByEmail(string email)
		{
            email = email.Trim().ToLower();
            return await _userRepository.GetByEmail(email);
		}
        public async Task<UserDetailsViewModel> GetInformation(int id)
		{
			var user = await _userRepository.GetById(id);
			if (user == null)
			{
				return null;
			}
			return new UserDetailsViewModel()
			{
				RegDate=user.RegDate,
				FirstName=user.FirstName,
				LastName=user.LastName,
				Email=user.Email,
				Mobile=user.Mobile,
				IsActive=user.IsActive,
				Id=user.Id,
			};
		}

    }
}
