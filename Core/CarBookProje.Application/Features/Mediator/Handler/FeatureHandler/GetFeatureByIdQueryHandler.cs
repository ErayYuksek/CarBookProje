using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBookProje.Application.Features.Mediator.Queries.FeatureQueries;
using CarBookProje.Application.Features.Mediator.Results.FeatureResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;


namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;
        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureID = values.FeatureID,
                Name = values.Name
            };
        }
    }
}