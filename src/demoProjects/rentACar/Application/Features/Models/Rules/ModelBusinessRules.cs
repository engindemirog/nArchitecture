using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Models.Rules
{
    public class ModelBusinessRules
    {
        private readonly IModelRepository _modelRepository;

        public ModelBusinessRules(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task ModelShouldExistWhenRequested(int id) {
            Model? model = await _modelRepository.GetAsync(m => m.Id == id);

            if (model == null) throw new BusinessException("Requsted Model Does Not Exists!");
        }
    }
}
