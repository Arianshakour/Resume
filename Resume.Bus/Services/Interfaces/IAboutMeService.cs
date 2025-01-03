using Resume.DLA.Entities.AboutMe;
using Resume.DLA.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Interfaces
{
    public interface IAboutMeService
    {
        Task<AdminEditAboutMeViewModel> GetInfo();
        Task<AdminEditAboutMeResult> Update(AdminEditAboutMeViewModel model);
        Task<ClientEditAboutMeViewModel> GetClientInfo();
    }
}
