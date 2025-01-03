using Microsoft.EntityFrameworkCore;
using Resume.DLA.Context;
using Resume.DLA.Entities.AboutMe;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Implementation
{
    public class AboutMeRespository : IAboutMeRespository
    {
        private readonly ResumeContext _context;
        public AboutMeRespository(ResumeContext context)
        {
            _context = context;
        }
        public async Task<AdminEditAboutMeViewModel> GetInfo()
        {
            var aboutme = await _context.AboutMeTable.FirstOrDefaultAsync();
            return new AdminEditAboutMeViewModel()
            {
                Id = aboutme.Id,
                FirstName = aboutme.FirstName,
                LastName = aboutme.LastName,
                Email = aboutme.Email,
                Mobile = aboutme.Mobile,
                Bio = aboutme.Bio,
                BrithDay = aboutme.BrithDay,
                Location = aboutme.Location,
                Position = aboutme.Position
            };
        }
        public async Task<AboutMe> Get()
        {
            return await _context.AboutMeTable.FirstOrDefaultAsync();
        }
        public void Update(AboutMe aboutMe)
        {
            _context.AboutMeTable.Update(aboutMe);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<ClientEditAboutMeViewModel> GetClientInfo()
        {
            var aboutme = await _context.AboutMeTable.FirstOrDefaultAsync().ConfigureAwait(false);
            return new ClientEditAboutMeViewModel()
            {
				Id = aboutme.Id,
				FirstName = aboutme.FirstName,
				LastName = aboutme.LastName,
				Email = aboutme.Email,
				Mobile = aboutme.Mobile,
				Bio = aboutme.Bio,
				BrithDay = aboutme.BrithDay,
				Location = aboutme.Location,
				Position = aboutme.Position
			};
        }

	}
}
