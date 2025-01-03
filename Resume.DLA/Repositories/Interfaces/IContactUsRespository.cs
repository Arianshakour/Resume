using Resume.DLA.Entities.ContactUs;
using Resume.DLA.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Interfaces
{
    public interface IContactUsRespository
    {
        Task InsertAsync(ContactUs contactUs);
        Task SaveAsync();
		Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model);
        Task<DetailsContactUsViewModel> GetByIdAsync(int id);
        Task<ContactUs> GetByIdFromModel (int id);
        void Update(ContactUs contactUs);

    }
}
