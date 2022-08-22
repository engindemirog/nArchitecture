using Application.Features.someFeature.Dtos;
using Application.Features.someFeature.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.someFeature.Commands.CreateSomeFeature
{
    public class CreateSomeFeatureEntityCommand : IRequest<CreatedSomeFeatureEntityDto>
    {
        public string Name { get; set; }
        public class CreateSomeFeatureEntityCommandHandler : IRequestHandler<CreateSomeFeatureEntityCommand, CreatedSomeFeatureEntityDto>
        {
            private readonly ISomeFeatureEntityRepository _someFeatureEntityRepository;
            private readonly IMapper _mapper;
            private readonly SomeFeatureEntityBusinessRules _someFeatureEntityBusinessRules;

            public CreateSomeFeatureEntityCommandHandler(ISomeFeatureEntityRepository someFeatureEntityRepository, IMapper mapper,
                                             SomeFeatureEntityBusinessRules someFeatureEntityBusinessRules)
            {
                _someFeatureEntityRepository = someFeatureEntityRepository;
                _mapper = mapper;
                _someFeatureEntityBusinessRules = someFeatureEntityBusinessRules;
            }

            public async Task<CreatedSomeFeatureEntityDto> Handle(CreateSomeFeatureEntityCommand request, CancellationToken cancellationToken)
            {
                await _someFeatureEntityBusinessRules.SomeFeatureEntityNameCanNotBeDuplicatedWhenInserted(request.Name);
                

                SomeFeatureEntity mappedSomeFeatureEntity = _mapper.Map<SomeFeatureEntity>(request);
                SomeFeatureEntity createdSomeFeatureEntity = await _someFeatureEntityRepository.AddAsync(mappedSomeFeatureEntity);
                CreatedSomeFeatureEntityDto createdSomeFeatureEntityDto = _mapper.Map<CreatedSomeFeatureEntityDto>(createdSomeFeatureEntity);
                return createdSomeFeatureEntityDto;
            }
        }
    }
}