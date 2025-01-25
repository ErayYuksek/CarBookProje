using CarBookProje.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBookProje.Application.Features.Mediator.Results.FooterAddressResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ID);
            return new GetFooterAddressByIdQueryResult
            {
                FooterID = values.FooterID,
                Adress= values.Adress,
                Description = values.Description,
                Email = values.Email,
                Phone = values.Phone
            };
        }
    }
}