using CarBookProje.Application.Features.CQRS.Results.AboutResults;
using CarBookProje.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
    {
        public int ID { get; set; }

        public GetFooterAddressByIdQuery(int id)
        {
            ID = id;
        }


    }
}
