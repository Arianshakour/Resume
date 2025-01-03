using Resume.DLA.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Interfaces
{
    public interface IEducationService
    {
        Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel filter);
        Task<CreateEducationResult> CreateAsync(CreateEducationViewModel model);
        Task<EditEducationResult> EditAsync(EditEducationViewModel model);
        Task<EditEducationViewModel> GetInfoById(int id);
        Task<DeleteEducationResult> DeleteAsync(DeleteEducationViewModel model);
        Task<DeleteEducationViewModel> GetIdForDelete(int id);
    }
}
