using CarBookProje.Application.Features.Mediator.Queries.AuthorQueries;
using CarBookProje.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProje.Application.Features.Mediator.Results.AuthorResults;
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
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
     private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
          var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Title = x.Title,
            }).ToList();
        }
    }
}
//}
//repository.GetAllAsync() ile veritabanından tüm blog kayıtlarını çeker.
//Çekilen her bir blog kaydını GetBlogQueryResult nesnesine dönüştürür.
//Bu verileri bir liste olarak döndürür (List<GetBlogQueryResult>).


//Bu kod, veritabanındaki tüm blogları listelemek için bir sorgu (query) işleyicisidir.

//İşleyiş:
//GetBlogQueryHandler:

//IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>> arayüzünü implemente eder.
//Veritabanından tüm blogları (GetAllAsync()) alır.
//Dönüş:

//Alınan blogları GetBlogQueryResult nesnelerine dönüştürerek bir liste (List<GetBlogQueryResult>) olarak döndürür.
//Her blogun şu bilgileri döner:
//AuthorID, BlogID, CategoryID, CoverImageUrl, CreatedDate, Title.
//Kısa Özet:
//Bu kod, blogların detaylı listesini almak için kullanılır. Veritabanından çekilen blogları formatlayıp döndürür.