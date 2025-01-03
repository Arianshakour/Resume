using Resume.Bus.Services.Interfaces;
using Resume.DLA.Entities.ContactUs;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Implementation
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRespository _contactUsRepository;
        private readonly IEmailService _emailService;
        private readonly IViewRenderService _viewRender;
        public ContactUsService(IContactUsRespository contactUsRepository, IEmailService emailService, IViewRenderService viewRender)
        {
            _contactUsRepository = contactUsRepository;
            _emailService = emailService;
            _viewRender = viewRender;
        }
        public async Task<CreateContactUsResult> CreateAsync(CreateContactUsViewModel model)
        {
            ContactUs contact = new ContactUs()
            {
                RegDate = DateTime.Now,
                Answer = null,
                Title= model.Title,
                Description= model.Description,
                Email= model.Email,
                FirstName= model.FirstName,
                LastName= model.LastName,
                Mobile= model.Mobile,
            };
            await _contactUsRepository.InsertAsync(contact);
            await _contactUsRepository.SaveAsync();
            return CreateContactUsResult.Success;
        }
        public async Task<FilterContactUsViewModel> FilterContactAsync(FilterContactUsViewModel model)
        {
            return await _contactUsRepository.FilterAsync(model);
        }
        public async Task<DetailsContactUsViewModel> GetByIdAsync(int id)
        {
            return await _contactUsRepository.GetByIdAsync(id);
        }
        public async Task<DetailResult> AnswerAsync(DetailsContactUsViewModel model)
        {
            var x = await _contactUsRepository.GetByIdFromModel(model.Id);
            if (x == null)
            {
                return DetailResult.NotFound;
            }
            if(string.IsNullOrEmpty(model.Answer))
            {
                return DetailResult.AnswerIsNull;
            }
            x.Answer = model.Answer;
            _contactUsRepository.Update(x);
            await _contactUsRepository.SaveAsync();
            string body = await _viewRender.RenderToStringAsync("Email/AnswerContactUs", model);
            await _emailService.SendEmail(x.Email,"پاسخ به تماس با ما", body);
            return DetailResult.Success;
        }
	}
}
