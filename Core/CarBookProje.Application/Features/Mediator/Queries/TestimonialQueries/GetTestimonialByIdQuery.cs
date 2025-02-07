using CarBookProje.Application.Features.Mediator.Results.SocialMediaResults;
using CarBookProje.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
    {
        public GetTestimonialByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
