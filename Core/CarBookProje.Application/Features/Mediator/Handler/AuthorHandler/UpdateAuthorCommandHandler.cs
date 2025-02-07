using CarBookProje.Application.Features.Mediator.Commands.AuthorCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.AuthorHandler
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AuthorID);
            values.Description = request.Description;
            values.Name = request.Name;
            values.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(values);
            return Unit.Value;

        }
    }
}


//Adımlar:
//Veritabanından Mevcut Verileri Alma:

//GetByIdAsync(request.AuthorID) ile güncellenecek olan yazarın mevcut verileri alınıyor.
//Bu, AuthorID bilgisine göre ilgili yazarın bulunmasını sağlıyor.
//Yeni Verilerle Güncelleme:

//Gelen request içindeki bilgiler (Description, Name, ImageUrl) alınarak bu değerler mevcut Author nesnesine (values) atanıyor.
//Örneğin:
//values.Description = request.Description;
//values.Name = request.Name;
//values.ImageUrl = request.ImageUrl;
//Güncelleme İşlemini Kaydetme:

//UpdateAsync(values) ile yeni değerlerle güncellenmiş olan yazar nesnesi veritabanına kaydediliyor.
//Sonuç:

//Güncelleme işlemi başarıyla tamamlandığında, Unit.Value döndürülerek işlemin bittiği bildiriliyor.
//Özet:
//Kod, Author tablosunda bir kaydı güncellemek için tasarlanmış. Gelen yeni bilgiler (API'den veya kullanıcıdan) alınıyor, önce veritabanından mevcut yazar bulunuyor, ardından bu bilgilerle yazar güncelleniyor ve veritabanına geri kaydediliyor. Bu, veriyi alıp güncelleme yapan bir işlem.