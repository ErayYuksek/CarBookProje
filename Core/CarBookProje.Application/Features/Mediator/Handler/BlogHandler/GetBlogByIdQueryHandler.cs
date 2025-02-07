using CarBookProje.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProje.Application.Features.Mediator.Results.BlogResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.BlogHandler
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {

        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.İd);
            return new GetBlogByIdQueryResult
            {
                AuthorID = values.AuthorID,
                BlogID = values.BlogID,
                CategoryID = values.CategoryID,
                CoverImageUrl = values.CoverImageUrl,
                CreatedDate = values.CreatedDate,
                Title = values.Title,
             
            };
        }
    }
}
