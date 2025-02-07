using CarBookProje.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBookProje.Application.Features.Mediator.Results.TestimonialResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.TestimonialHandler
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
         var values=await _repository.GetAllAsync();
            return values.Select(x=> new GetTestimonialQueryResult
            {
                TestimonialID = x.TestimonialID,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Title = x.Title

            }
            ).ToList();
        }
    }
}


//Bu kod, veritabanındaki tüm Testimonial (örneğin müşteri yorumları) verilerini getirir ve bunları bir liste halinde döndürür. Az önceki kod, yalnızca tek bir ID'ye ait yorumu getirirken, bu kod bütün yorumları çeker.

//Bu Kod Ne Yapıyor?
//1. Amaç
//Kod, veritabanındaki tüm Testimonial kayıtlarını (müşteri yorumları) sorgular.
//Bu yorumları, belirli bir formatta (GetTestimonialQueryResult listesi) döndürür.
//2. Adım Adım Açıklama
//Tüm Verileri Çekme:

//await _repository.GetAllAsync() metodu kullanılarak, Testimonial (müşteri yorumları) tablosundaki tüm veriler çekiliyor:
//csharp
//Kodu kopyala
//var values = await _repository.GetAllAsync();
//Verileri Formatlama:

//Veritabanından gelen her bir yorum, GetTestimonialQueryResult formatına dönüştürülüyor:
//csharp
//Kodu kopyala
//values.Select(x => new GetTestimonialQueryResult
//                   {
//                       TestimonialID = x.TestimonialID,
//                       Comment = x.Comment,
//                       ImageUrl = x.ImageUrl,
//                       Name = x.Name,
//                       Title = x.Title
//                   }).ToList();
//Select Metodu: Her bir kaydı, GetTestimonialQueryResult nesnesine çevirir.
//Sonuç, bir listeye (ToList()) dönüştürülerek döndürülür.
//Sonuç Döndürme:

//Bütün yorumlar, API ya da başka bir sisteme bu liste şeklinde geri gönderilir:
//csharp
//Kodu kopyala
//return values.Select(...).ToList();

