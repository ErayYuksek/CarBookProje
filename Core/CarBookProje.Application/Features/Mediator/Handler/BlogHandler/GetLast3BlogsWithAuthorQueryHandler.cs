using CarBookProje.Application.Features.CQRS.Results.CarResults;
using CarBookProje.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProje.Application.Features.Mediator.Results.BlogResults;
using CarBookProje.Application.Interfaces;
using CarBookProje.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Handler.BlogHandler
{
    public class GetLast3BlogsWithAuthorQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetLast3BlogsWithAuthors();
            return values.Select(x => new GetLast3BlogsWithAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                AuthorName = x.AuthorName,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title
            }).ToList();
        }
    }
}
