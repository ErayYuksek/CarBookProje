using CarBookProje.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBookProje.Application.Features.Mediator.Results.TagCloudResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.TagCloudHandler
{
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagCloudQueryResult
            {
                Title = x.Title,
                TagCloudId = x.TagCloudId,
                BlodID = x.BlogID
            }
            ).ToList();
        }
    }
}
