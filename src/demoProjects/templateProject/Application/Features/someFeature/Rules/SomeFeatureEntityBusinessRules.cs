using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.someFeature.Rules
{
    public class SomeFeatureEntityBusinessRules
    {
        private readonly ISomeFeatureEntityRepository _someFeatureEntityRepository;

        public SomeFeatureEntityBusinessRules(ISomeFeatureEntityRepository someFeatureEntityRepository)
        {
            _someFeatureEntityRepository = someFeatureEntityRepository;
        }

        public async Task SomeFeatureEntityNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<SomeFeatureEntity> result = await _someFeatureEntityRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("SomeFeatureEntity name exists.");
        }
    }
}
