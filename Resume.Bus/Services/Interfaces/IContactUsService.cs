using Resume.DLA.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Interfaces
{
    public interface IContactUsService
    {
        Task<CreateContactUsResult> CreateAsync(CreateContactUsViewModel model);
        Task<FilterContactUsViewModel> FilterContactAsync(FilterContactUsViewModel model);
        Task<DetailsContactUsViewModel> GetByIdAsync(int id);
        Task<DetailResult> AnswerAsync(DetailsContactUsViewModel model);
    }
}
