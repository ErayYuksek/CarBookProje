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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                Icon = values.Icon,
                Name = values.Name,
                Url = values.Url,
                SocialMediaID = values.SocialMediaID,
            };
        }
    }
}
