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
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
        {
            _repository = blogRepository;
        }

        public  async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values= _repository.GetBlogByAuthorId(request.Id);
            return values.Select(x=> new GetBlogByAuthorIdQueryResult
            {
                AuthorID=x.AuthorID,
                BlogID=x.BlogID,
                AuthorName=x.AuthorName,
                AuthorDescription=x.Author.Description,
                AuthorImageUrl=x.Author.ImageUrl,
             
            }
            ).ToList();
        }
    }
}
