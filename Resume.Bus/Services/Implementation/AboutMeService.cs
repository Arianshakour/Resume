using Resume.Bus.Services.Interfaces;
using Resume.DLA.Entities.AboutMe;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Implementation
{
    public class AboutMeService : IAboutMeService
    {
        private readonly IAboutMeRespository _aboutMe;
        public AboutMeService(IAboutMeRespository aboutMe)
        {
            _aboutMe = aboutMe;
        }
        public async Task<AdminEditAboutMeViewModel> GetInfo()
        {
            return await _aboutMe.GetInfo();
        }
        public async Task<AdminEditAboutMeResult> Update(AdminEditAboutMeViewModel model)
        {
            if (model == null)
            {
                return AdminEditAboutMeResult.NotFound;
            }
            var x = await _aboutMe.Get();
            x.FirstName = model.FirstName;
            x.LastName = model.LastName;
            x.Email = model.Email;
            x.Mobile = model.Mobile;
            x.Position = model.Position;
            x.Bio = model.Bio;
            x.BrithDay = model.BrithDay;
            x.Location = model.Location;
            _aboutMe.Update(x);
            await _aboutMe.SaveAsync();
            return AdminEditAboutMeResult.Success;
        }
        public async Task<ClientEditAboutMeViewModel> GetClientInfo()
        {
            return await _aboutMe.GetClientInfo();
        }

	}
}
