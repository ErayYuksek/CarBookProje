using CarBookProje.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProje.Application.Features.CQRS.Results.AboutResults;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.AboutHandler
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            await _repository.CreateAsync(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl
            });
        }

    }
}
//Nesne Oluşturma: Kullanıcıdan gelen "Title" (Başlık), "Description" (Açıklama) ve "ImageUrl" (Resim Bağlantısı) gibi bilgileri, bir "About" nesnesine dönüştürüyor.

//Veritabanına Kaydetme: _repository.CreateAsync fonksiyonunu çağırarak, bu yeni About nesnesini veritabanına ekliyor.

//Neden Var? Bu işlem, sistemin "Hakkında" bölümüne yeni bilgi eklemesini sağlıyor. Daha düzenli ve güvenli bir yapı oluşturmak için yazılmış.