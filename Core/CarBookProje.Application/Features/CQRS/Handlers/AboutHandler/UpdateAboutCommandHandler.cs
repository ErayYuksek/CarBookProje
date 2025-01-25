using CarBookProje.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.AboutHandler
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AboutID);
            values.Title = command.Title;
            values.Description = command.Description;
            values.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
//}
//Mevcut Kaydı Bulma:

//GetByIdAsync(command.AboutID) ile veritabanındaki güncellenmek istenen kayıt, AboutID üzerinden bulunuyor.
//Gelen Bilgilerle Güncelleme:

//values.Title, command.Title ile değiştiriliyor (yeni başlık atanıyor).
//values.Description ve values.ImageUrl de aynı şekilde yeni değerlerle güncelleniyor.
//Değişiklikleri Kaydetme:

//_repository.UpdateAsync(values) çağrılarak güncellenmiş kayıt, veritabanına geri kaydediliyor.