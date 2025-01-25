using CarBookProje.Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace CarBookProje.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
    {
        public int Id { get; set; }

        public GetLocationByIdQuery(int ıd)
        {
            Id = ıd;
        }


    }
}
