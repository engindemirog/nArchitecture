using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Queries.GetByIdModel;
public class GetByIdModelQuery : IRequest<ModelGetbyIdDto>
{
    public int Id { get; set; }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdModelQuery, ModelGetbyIdDto>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        private readonly ModelBusinessRules _modelBusinessRules;

        public GetByIdQueryHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<ModelGetbyIdDto> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
        {
            await _modelBusinessRules.ModelShouldExistWhenRequested(request.Id);
            // not null controlled in ModdelBusinessRules
            Model? model = await _modelRepository.GetAsync(m => m.Id == request.Id);
            ModelGetbyIdDto mappedModel = _mapper.Map<ModelGetbyIdDto>(model);

            return mappedModel;
        }
    }
}