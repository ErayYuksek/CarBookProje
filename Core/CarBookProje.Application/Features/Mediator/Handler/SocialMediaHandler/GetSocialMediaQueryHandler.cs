using CarBookProje.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBookProje.Application.Features.Mediator.Results.SocialMediaResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.SocialMediaHandler
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetSocialMediaQueryResult
            {
                Icon= x.Icon,
                Name= x.Name,
                Url= x.Url,
                SocialMediaID= x.SocialMediaID,
            }
            ).ToList();
   
        }
    }
}
