using CarBookProje.Application.Features.Mediator.Queries.ServiceQueries;
using CarBookProje.Application.Features.Mediator.Results.ServiceResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.ServiceHandler
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            return new GetServiceByIdQueryResult
            {
                Desciription = values.Desciription,
                IconUrl = values.IconUrl,
                Title = values.Title,
                ServiceID = values.ServiceID
            };


        }
    }
}
