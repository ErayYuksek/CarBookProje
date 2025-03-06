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
	public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogWithAuthorQueryResult>>
	{ 
		private readonly IBlogRepository _repository;

		public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public  async Task<List<GetAllBlogWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values =  _repository.GetAllBlogWithAuthors();
			return values.Select(x => new GetAllBlogWithAuthorQueryResult
			{
				AuthorID = x.AuthorID,
				AuthorName = x.AuthorName,
				BlogID = x.BlogID,
				CategoryID = x.CategoryID,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				Descripton = x.Description,
				AuthorDescription = x.Author.Description,
				AuthorImageUrl = x.Author.ImageUrl,
			}).ToList();
		}
	}
}

// veritabanından alınan veriyi süzüp Swagger'a gönderdik! 

