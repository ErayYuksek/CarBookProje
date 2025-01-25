using CarBookProje.Application.Features.Mediator.Queries.FeatureQueries;
using CarBookProje.Application.Features.Mediator.Results.FeatureResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.FeatureHandler
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFooteAddressQueryResult>>

    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooteAddressQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetFooteAddressQueryResult
            {
                FeatureID= x.FeatureID, 
                Name= x.Name,   
            }).ToList();
            
        }


    }
}
