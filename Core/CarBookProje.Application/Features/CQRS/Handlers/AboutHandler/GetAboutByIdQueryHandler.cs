using CarBookProje.Application.Features.CQRS.Queries.AboutQueries;
using CarBookProje.Application.Features.CQRS.Results.AboutResults;
using CarBookProje.Application.Interfaces;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.AboutHandler
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutID = values.AboutID,
                Title = values.Title,
                Description = values.Description,
                ImageUrl = values.ImageUrl

            };

        }
    }
}

//Bilgi Almak:

//Kullanıcı veya sistem, bir ID (kimlik) ile belirli bir "Hakkında" kaydını görmek istiyor.
//query.Id kullanılarak, veritabanındaki o kayda ulaşılıyor.
//Bilgi İşlemek:

//_repository.GetByIdAsync(query.Id) metodu, veritabanından bu ID'ye sahip kaydı bulur ve getirir.
//Sonuç Döndürmek:

//Gelen veriler(örneğin, Başlık, Açıklama ve Resim URL'si) bir GetAboutByIdQueryResult nesnesine yerleştirilir.
//Bu nesne, sorgulayan kişiye (kullanıcıya veya başka bir sisteme) döndürülür.
//Ne İşe Yarıyor?
//Kısacası, bir kullanıcının belirli bir "Hakkında" kaydını görmesine olanak sağlıyor. Kullanıcı sadece ID verir, sistem gerekli bilgileri veritabanından alır ve döndürür.

//Örnek:

//Kullanıcı bir Hakkında sayfasını açmak istediğinde:
//Kullanıcı ID: 123
//Bu kod, ID 123'e ait bilgileri alır ve sonucu döndürür (örneğin: Başlık: "Hakkımızda", Açıklama: "Biz bir teknoloji şirketiyiz").