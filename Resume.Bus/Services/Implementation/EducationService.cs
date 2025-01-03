using Resume.Bus.Services.Interfaces;
using Resume.DLA.Entities.Education;
using Resume.DLA.Repositories.Interfaces;
using Resume.DLA.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Implementation
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _repository;

        public EducationService(IEducationRepository repository)
        {
            _repository = repository;
        }
        public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel filter)
        {
            return await _repository.FilterAsync(filter);
        }
        public async Task<CreateEducationResult> CreateAsync(CreateEducationViewModel model)
        {
            Education education = new Education()
            {
                Title = model.Title,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                CreateOn = DateTime.Now
            };
            await _repository.Insert(education);
            await _repository.Save();
            return CreateEducationResult.Success;
        }
        public async Task<EditEducationResult> EditAsync(EditEducationViewModel model)
        {
            var edc = await _repository.GetById(model.Id);
            if (edc == null)
            {
                return EditEducationResult.NotFound;
            }
            edc.Title = model.Title;
            edc.Description = model.Description;
            edc.Start = model.Start;
            edc.End = model.End;
            _repository.Update(edc);
            await _repository.Save();
            return EditEducationResult.Success;
        }
        public async Task<EditEducationViewModel> GetInfoById(int id)
        {
            return await _repository.GetInfoById(id);
        }
        public async Task<DeleteEducationResult> DeleteAsync(DeleteEducationViewModel model)
        {
            var dlt = await _repository.GetById(model.Id);
            if (dlt == null)
            {
                return DeleteEducationResult.Error;
            }
            _repository.Delete(dlt);
            await _repository.Save();
            return DeleteEducationResult.Success;
        }
        public async Task<DeleteEducationViewModel> GetIdForDelete(int id)
        {
            return await _repository.GetIdForDelete(id);
        }
    }

}
