using CarBookProje.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdQuery:IRequest<GetBlogByIdQueryResult>
    {
        public GetBlogByIdQuery(int id)
        {
            BlogID = id;
        }
 
        public int BlogID { get; set; }
    }
}
