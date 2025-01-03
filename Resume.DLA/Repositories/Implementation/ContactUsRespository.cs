using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Resume.DLA.Context;
using Resume.DLA.Entities.ContactUs;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Implementation
{
    public class ContactUsRespository : IContactUsRespository
    {
        private readonly ResumeContext _context;
        public ContactUsRespository(ResumeContext context)
        {
            _context = context;
        }
        public async Task InsertAsync(ContactUs contactUs)
        {
            await _context.AddAsync(contactUs);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model)
        {
            var query = _context.ContactUsTable.OrderByDescending(x => x.RegDate).AsQueryable();
            Console.WriteLine($"Selected Status: {model.Status}");
            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{model.Title}%"));
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                query = query.Where(x => EF.Functions.Like(x.Email, $"%{model.Email}%"));
            }
			if (!string.IsNullOrEmpty(model.Mobile))
			{
				query = query.Where(x => EF.Functions.Like(x.Mobile, $"%{model.Mobile}%"));
			}
			if (!string.IsNullOrEmpty(model.FirstName))
			{
				query = query.Where(x => EF.Functions.Like(x.FirstName, $"%{model.FirstName}%"));
			}
			if (!string.IsNullOrEmpty(model.LastName))
			{
				query = query.Where(x => EF.Functions.Like(x.LastName, $"%{model.LastName}%"));
			}
			switch (model.Status)
			{
				case FilterContactUsResult.All:
					break;
				case FilterContactUsResult.JavabDade:
                    query = query.Where(x => x.Answer != null);
					break;
				case FilterContactUsResult.JavabNadade:
                    query = query.Where(x => x.Answer == null);
					break;
			}
            await model.Paging(query.Select(x => new DetailsContactUsViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Answer = x.Answer,
                Title = x.Title,
                Description = x.Description,
                RegDate=x.RegDate,
                Email = x.Email,
                Mobile = x.Mobile,
            }));
            return model;

		}
        public async Task<DetailsContactUsViewModel> GetByIdAsync(int id)
        {
            var query = await _context.ContactUsTable.FirstOrDefaultAsync(x => x.Id == id);
            return new DetailsContactUsViewModel()
            {
                Answer = query.Answer,
                Title = query.Title,
                Description = query.Description,
                Id = query.Id,
                FirstName = query.FirstName,
                LastName = query.LastName,
                Email = query.Email,
                Mobile = query.Mobile,
                RegDate = query.RegDate
            };
        }
        public async Task<ContactUs> GetByIdFromModel(int id)
        {
            return await _context.ContactUsTable.FirstOrDefaultAsync(x => x.Id == id);
        }
        public void Update(ContactUs contactUs)
        {
            _context.ContactUsTable.Update(contactUs);
        }
	}
}