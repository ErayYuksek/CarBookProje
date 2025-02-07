using CarBookProje.Application.Features.Mediator.Queries.AuthorQueries;
using CarBookProje.Application.Features.Mediator.Results.AuthorResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.AuthorHandler
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }
    }
}
