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

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
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
            Console.WriteLine($"Gelen Blog ID: {request.BlogID}");

            if (request.BlogID == 0)
            {
                throw new Exception("HATA: Gelen Blog ID geçersiz! (0)");
            }

            if (request.BlogID == null)
            {
                throw new Exception("HATA: Blog ID NULL geldi!");
            }

            var values = await _repository.GetByIdAsync(request.BlogID);

            if (values == null)
            {
                throw new Exception($"HATA: Veritabanında Blog bulunamadı! BlogID: {request.BlogID}");
            }

            return new GetBlogByIdQueryResult
            {
                AuthorID = values.AuthorID,
                BlogID = values.BlogID,
                CategoryID = values.CategoryID,
                CoverImageUrl = values.CoverImageUrl,
                CreatedDate = values.CreatedDate,
                Title = values.Title,
                Description = values.Description

            };
        }

    }
}