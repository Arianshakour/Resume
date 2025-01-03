using Resume.DLA.Entities.AboutMe;
using Resume.DLA.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Interfaces
{
    public interface IAboutMeRespository
    {
        Task<AdminEditAboutMeViewModel> GetInfo();
        Task<AboutMe> Get();
        void Update (AboutMe aboutMe);
        Task SaveAsync();
        Task<ClientEditAboutMeViewModel> GetClientInfo();

	}
}
