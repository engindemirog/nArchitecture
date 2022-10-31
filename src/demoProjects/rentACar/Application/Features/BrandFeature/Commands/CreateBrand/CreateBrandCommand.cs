using Application.Features.BrandFeature.Dtos;
using Application.Features.BrandFeature.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandFeature.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }
        public class CreateSomeFeatureEntityCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandsBusinessRules;
            public CreateSomeFeatureEntityCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandsBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandsBusinessRules = brandsBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandsBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand createdBrandEntity = await _brandRepository.AddAsync(mappedBrand);
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrandEntity);

                return createdBrandDto;
            }
        }
    }
}
