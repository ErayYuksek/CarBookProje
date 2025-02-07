using CarBookProje.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBookProje.Application.Features.Mediator.Results.SocialMediaResults;
using CarBookProje.Application.Features.Mediator.Results.TestimonialResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.TestimonialHandler
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetByIdAsync(request.Id);

            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = values.TestimonialID,
                Comment = values.Comment,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                Title = values.Title

            };
        }
    }
}


//1.Gelen Sorguyu İşleme
//Kod, GetTestimonialByIdQuery adlı bir sorgu alıyor. Bu sorgunun içinde, hangi kaydı (örneğin bir müşteri yorumu) istediğimizi belirten bir ID var.
//Örnek: Sorgu request.Id = 5 içeriyorsa, bu kod, ID'si 5 olan müşteri yorumunu bulmaya çalışıyor.
//2. Veritabanından Veri Çekme
//_repository.GetByIdAsync(request.Id) fonksiyonu çağrılıyor.
//Bu, ID'si sorgudan gelen değere (örneğin 5) eşit olan Testimonial (müşteri yorumu) kaydını veritabanından getiriyor.
//values değişkenine, veritabanından gelen müşteri yorumu atanıyor.
//3. Sonuç Nesnesi Döndürme
//Veritabanından alınan veriyi (values), GetTestimonialByIdQueryResult adlı bir sonuç nesnesine dönüştürüyor.
//Bu sonuç nesnesi, şu bilgileri içeriyor:
//TestimonialID: Yoruma ait benzersiz kimlik.
//Comment: Yorumun metni.
//ImageUrl: Yoruma bağlı bir resmin adresi.
//Name: Yorumu yapan kişinin adı.
//Title: Yorumu yapan kişinin unvanı (ör. "Müşteri").
//Sonuç olarak, bu nesne döndürülüyor ve başka bir yerde (örneğin bir API'de veya ekranda) kullanılabilir.

//Kısaca:
//Bu kod:

//ID'si verilen müşteri yorumunu bulur.
//Bu yorumu belirli bir formatta (örneğin JSON gibi) döndürmek için düzenler.
//Anlaşılmayan bir yer varsa, daha da basitleştirerek açıklayabilirim! 😊












