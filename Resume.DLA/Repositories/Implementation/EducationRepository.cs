using Microsoft.EntityFrameworkCore;
using Resume.DLA.Context;
using Resume.DLA.Entities.Education;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Repositories.Implementation
{
    public class EducationRepository : IEducationRepository
    {
        private readonly ResumeContext _context;

        public EducationRepository(ResumeContext context)
        {
            _context = context;
        }

        public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel filter)
        {
            var query = _context.Educations.AsQueryable();
            if(!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(x=>x.Title.Contains(filter.Title));
            }
            if (filter.Start.HasValue)
            {
                query = query.Where(x=>x.Start>=filter.Start);
            }
            if(filter.End.HasValue)
            {
                query = query.Where(x=> x.End<=filter.End);
            }
            await filter.Paging(query.Select(x => new DetalisEducationViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Start = x.Start,
                End = x.End,
                Description = x.Description,
                CreateOn = x.CreateOn,
            }));
            return filter;
        }

        public async Task<Education?> GetById(int id)
        {
            return await _context.Educations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Education education)
        {
            await _context.Educations.AddAsync(education);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Education education)
        {
            _context.Educations.Update(education);
        }
        public async Task<EditEducationViewModel> GetInfoById(int id)
        {
            var edc = await _context.Educations.FirstOrDefaultAsync(x=> x.Id == id);
            return new EditEducationViewModel()
            {
                Id = edc.Id,
                Title = edc.Title,
                Start = edc.Start,
                End= edc.End,
                Description = edc.Description
            };
        }
        public async Task<DeleteEducationViewModel> GetIdForDelete(int id)
        {
            var x = await _context.Educations.FirstOrDefaultAsync(x => x.Id == id);
            return new DeleteEducationViewModel()
            {
                Id = x.Id,
                Title = x.Title
            };
        }
        public void Delete(Education education)
        {
            _context.Educations.Remove(education);
        }
    }
}
