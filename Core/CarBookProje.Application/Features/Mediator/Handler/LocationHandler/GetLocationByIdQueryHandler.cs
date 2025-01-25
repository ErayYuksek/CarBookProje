using CarBookProje.Application.Features.Mediator.Queries.LocationQueries;
using CarBookProje.Application.Features.Mediator.Results.LocationResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.LocationHandler
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult
            {
                LocationID = value.LocationID,
                Name = value.Name,

            };
          

        }
    }
}
