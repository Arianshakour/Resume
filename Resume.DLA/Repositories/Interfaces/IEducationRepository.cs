using Resume.DLA.Entities.Education;
using Resume.DLA.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel filter);
        Task Insert(Education education);
        void Update(Education education);
        Task Save();
        Task<Education?> GetById(int id);
        Task<EditEducationViewModel> GetInfoById(int id);
        Task<DeleteEducationViewModel> GetIdForDelete(int id);
        void Delete(Education education);

    }
}
