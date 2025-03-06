using CarBookProje.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBookProje.Application.Features.Mediator.Results.TagCloudResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.TagCloudHandler
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.id);

            if (value == null)
            {
                return null; // veya default değerler içeren bir nesne dönebilirsin.
            }

            return new GetTagCloudByIdQueryResult
            {
                TagCloudId = value.TagCloudId,
                Title = value.Title,
                BlodID = value.BlogID
            };
        }

    }
}
