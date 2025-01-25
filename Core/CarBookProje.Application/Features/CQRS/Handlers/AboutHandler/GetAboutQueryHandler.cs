using CarBookProje.Application.Features.CQRS.Results.AboutResults;
using CarBookProje.Application.Interfaces;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.AboutHandler
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutID = x.AboutID,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
//}
//Tüm Verileri Almak:

//GetAllAsync() metodu ile veritabanındaki bütün "Hakkında" kayıtları (ör. başlık, açıklama, resim) alınıyor.
//Her Bir Kaydı İşlemek:

//Alınan her kayıt, GetAboutQueryResult adlı bir nesneye dönüştürülüyor.
//Örneğin, veritabanındaki "Title" alanı, GetAboutQueryResult içindeki "Title" olarak ayarlanıyor.
//Liste Halinde Döndürmek:

//Tüm kayıtlar işlendiğinde bir listeye (ToList()) dönüştürülüyor ve geriye döndürülüyor.

//Veri Kaynağı:

//Veriler ilk olarak _repository.GetAllAsync() metodu ile veritabanından alınıyor.
//Bu işlem, tüm About (Hakkında) kayıtlarını alır.
//Dönüştürme İşlemi:

//Gelen About nesneleri, Select metodu ile GetAboutQueryResult nesnelerine dönüştürülüyor.