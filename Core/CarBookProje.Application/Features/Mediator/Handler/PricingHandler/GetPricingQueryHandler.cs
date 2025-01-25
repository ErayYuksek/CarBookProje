using CarBookProje.Application.Features.Mediator.Queries.PricingQueries;
using CarBookProje.Application.Features.Mediator.Results.PricingResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.PricingHandler
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {

        private readonly IRepository<Pricing> _repository;

        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        async Task<List<GetPricingQueryResult>> IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>.Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetPricingQueryResult
            {
                Name = x.Name,
                PricingID = x.PricingID
            }
            ).ToList();
        }
    }
}
