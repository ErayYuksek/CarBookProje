using CarBookProje.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBookProje.Application.Features.Mediator.Results.FooterAddressResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.FooterAddressHandler
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                Adress = x.Adress, // "Adress" yerine "Address" yazımına dikkat
                Description = x.Description,
                Email = x.Email,
                FooterID = x.FooterID,
                Phone = x.Phone
            }).ToList();
        }
    }
}
