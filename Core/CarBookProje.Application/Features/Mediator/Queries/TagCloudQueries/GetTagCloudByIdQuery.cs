using CarBookProje.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery:IRequest<GetTagCloudByIdQueryResult>
    {
        public GetTagCloudByIdQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
